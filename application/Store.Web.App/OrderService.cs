using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

using Store.Messages;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using PhoneNumbers;

namespace Store.Web.App
{
    public class OrderService
    {
        private readonly IProductRepository productRepository;
        private readonly IOrderRepository orderRepository;
        private readonly INotificationService notificationService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ProductService productService;
        protected ISession session => httpContextAccessor.HttpContext.Session;
        public OrderService(IProductRepository productRepository, IOrderRepository orderRepository, INotificationService notificationService, IHttpContextAccessor httpContextAccessor,ProductService productService)
        {
            this.productRepository = productRepository;
            this.orderRepository = orderRepository;
            this.notificationService = notificationService;
            this.httpContextAccessor = httpContextAccessor;
            this.productService= productService;
        }
        public bool TryGetModel(out OrderModel model)
        {
            if (TryGetOrder(out Order order))
            {
                model = Map(order);
                return true;
            }
            model = null;
            return false;
        }
        internal bool TryGetOrder(out Order order)
        {
            if (session.TryGetCart(out Cart cart))
            {
                order = orderRepository.GetById(cart.OrderId);
                
                return true;
            }
            order = null;
            return false;
        }
        private OrderModel Map(Order order)
        {
            var products = GetProducts(order);
            var items = from item in order.Items
                        join product in products on item.ProductId equals product.id
                        select new OrderItemModel
                        {
                            ProductId = product.id,
                            Name = product.name,
                            Count = item.Count,
                            Price = item.Price,

                        };
            return new OrderModel
            {
                Id = order.Id,
                items = items.ToList<OrderItemModel>(),
                TotalCount = order.totalcount,
                TotalPrice = order.totalPrice,
                Cellphone=order.CellPhone,
                deliveryDescription=order.Delivery?.Description,
                paymentDescription=order.Payment?.Description,
            };
        }
        internal IEnumerable<Product> GetProducts(Order order)
        {
            
          var productids=order.Items.Select(item => item.ProductId);
          return productRepository.GetAllByIds(productids);
            
            
        }
        public OrderModel AddProduct(int productid,int count)
        {

            if(!TryGetOrder(out Order order))
            {
                order = orderRepository.Create();
            }
            AddorUpdateProduct(order, productid, count);
            UpdateSession(order);
            return Map(order);
        }
        public OrderModel UpdateProduct(int productid,int count)
        {
            var order = GetOrder();
            order.Items.Get(productid).Count = count;
            orderRepository.Update(order);
            UpdateSession(order);
            return Map(order);
        }
        public OrderModel RemoveBook(int productid)
        {
            var order = GetOrder();
            order.Items.Remove(productid);
            if (order.Items.Count == 0)
            {
                UpdateSession(order);
                order = GetOrder();
                return Map(order);
            }
            orderRepository.Update(order);
            
            return Map(order);
        }

        public Order GetOrder()
        {
            if (TryGetOrder(out Order order))
                return order;
            throw new InvalidCastException();
        }

        private void UpdateSession(Order order)
        {
            var cart = new Cart(order.Id, order.totalcount, order.totalPrice); 
            session.Set(cart);
        }

        internal void AddorUpdateProduct(Order order, int productid, int count)
        {
            if (count < 0)
            {
                try
                {
                    if (order.Items.Get(productid).Count == 1)
                    {
                        var neworder = RemoveBook(productid);
                        orderRepository.Update(order);

                    }
                    else
                    {
                        order.Items.Get(productid).Count += count;
                        orderRepository.Update(order);
                    }
                }
                catch
                {

                    var product = productService.GetById(productid);
                    if (order.Items.TryGet(productid, out var item))
                    {
                        item.Count += count;
                        orderRepository.Update(order);
                    }
                    else
                    {
                        order.Items.Add(productid, product.price, product.name, count);
                        orderRepository.Update(order);
                    }
                }
            }
            else
            {
                var product = productService.GetById(productid);
                if (order.Items.TryGet(productid, out var item))
                {
                    item.Count += count;
                    orderRepository.Update(order);
                }
                else {
                    order.Items.Add(productid, product.price, product.name, count);
                    orderRepository.Update(order);
                }
            }


        }
        public OrderModel SendConfirmation(string cellPhone)
        {
            var order = GetOrder();
            var model = Map(order);

            if (TryFormatPhone(cellPhone, out string formattedPhone))
            {
                var confirmationCode = 1111; // todo: random.Next(1000, 10000) = 1000, 1001, ..., 9998, 9999
                model.CellPhone = formattedPhone;
                session.SetInt32(formattedPhone, confirmationCode);
                notificationService.SendConfirmationCode(formattedPhone, confirmationCode);
            }
            else
                model.Errors["cellPhone"] = "Номер телефона не соответствует формату +79876543210";

            return model;
        }
        private readonly PhoneNumberUtil phoneNumberUtil = PhoneNumberUtil.GetInstance();
        internal bool TryFormatPhone(string cellPhone, out string formattedPhone)
        {
            try
            {
                var phoneNumber = phoneNumberUtil.Parse(cellPhone, "ru");
                formattedPhone = phoneNumberUtil.Format(phoneNumber, PhoneNumberFormat.INTERNATIONAL);
                return true;
            }
            catch (NumberParseException)
            {
                formattedPhone = null;
                return false;
            }
        }
        public OrderModel ConfirmCellPhone(string cellPhone, int confirmationCode)
        {
            int? storedCode = session.GetInt32(cellPhone);
            var model = new OrderModel();

            if (storedCode == null)
            {
                model.Errors["cellPhone"] = "Что-то случилось. Попробуйте получить код ещё раз.";
                return model;
            }

            if (storedCode != confirmationCode)
            {
                model.Errors["confirmationCode"] = "Неверный код. Проверьте и попробуйте ещё раз.";
                return model;
            }

            var order = GetOrder();
            order.CellPhone = cellPhone;
            orderRepository.Update(order);

            session.Remove(cellPhone);

            return Map(order);
        }
        public OrderModel SetDelivery(OrderDelivery delivery)
        {
            var order = GetOrder();
            order.Delivery = delivery;
            orderRepository.Update(order);

            return Map(order);
        }
        public OrderModel SetPayment(OrderPayment payment)
        {
            var order = GetOrder();
            order.Payment = payment;
            orderRepository.Update(order);
            session.RemoveCart();

            return Map(order);
        }

    }
}

