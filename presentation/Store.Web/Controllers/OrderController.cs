using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using Store.Web.Models;
using System.Data;
using System.Text.RegularExpressions;
using Store.Messages;
using Store.Contractors;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Store.Web.Contractors;
using Store.Web.App;
using Newtonsoft.Json.Linq;
namespace Store.Web.Controllers
{
    public class OrderController : Controller
    {
        private ProductService productService;
      
        private readonly INotificationService notificationService;
        private readonly IEnumerable<IDeliveryService> deliveryServices;
        private readonly IEnumerable<IPaymentService> paymentServices;
        private readonly IEnumerable<IWebContractorService> webContractorServices;
        private readonly IUserRepository userRepository;
        private readonly UserService userService;
        private readonly OrderService orderService;
        public OrderController(ProductService productservice, INotificationService NotificationService, IEnumerable<IPaymentService> paymentServices,IEnumerable<IDeliveryService> deliveryServices,IUserRepository userRepository, IEnumerable<IWebContractorService> webContractorServices,OrderService orderservice,UserService userservice)
        {
            productService = productservice;
            notificationService = NotificationService;
            this.deliveryServices = deliveryServices;
            this.userRepository = userRepository;
            this.webContractorServices = webContractorServices;
             this.paymentServices= paymentServices;
            this.orderService=orderservice;
            this.userService=userservice;
        }

        [HttpPost]
        public IActionResult AddItem(int id)
        {
            orderService.AddProduct(id, 1);
            return RedirectToAction("Index", "Desc", new { id });
        }
        public IActionResult Delete(int id)
        {
            orderService.RemoveBook(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Index()
        {
            if (orderService.TryGetModel(out OrderModel ordermodel))
            {
                if (ordermodel.items.Count==0)
                    return View("Empty");
                return View(ordermodel);
            }
            return View("Empty");
          

        }
        public IActionResult IncreaseItem(int id)
        {
            orderService.AddProduct(id, 1);
            return RedirectToAction("Index");
        }
        public IActionResult DecreaseOneItem(int id)
        {
            orderService.AddProduct(id, -1);
            return RedirectToAction("Index");
        }



        [HttpPost]
        [Authorize]
        public IActionResult SendConfirmation(string cellphone)
        {
            var model = orderService.SendConfirmation(cellphone);
            return View("Confirmation",model);
        }
       
    
        [HttpPost]
        public IActionResult ConfirmCellPhone(int confirmationCode, string cellPhone)
        {
            var model = orderService.ConfirmCellPhone(cellPhone,confirmationCode);
            if (model.Errors.Count > 0)
            {
                return View("Confirmation", model);
            }
            var deliveryMethods = deliveryServices.ToDictionary(service => service.Name,
                                                                service => service.Title);

            var email = HttpContext.User.FindFirst(ClaimTypes.Name);
            var StringEmail = email.Value;
            var user = userRepository.GetByEmail(StringEmail);
            user.CellPhone = cellPhone;
            userRepository.Update(user);
            HttpContext.Session.Remove(cellPhone);

            return View("DeliveryMethod", deliveryMethods);

        }
        [HttpPost]
        public IActionResult StartDelivery(string serviceName)
        {
            var deliveryService = deliveryServices.Single(service => service.Name == serviceName);
            var order = orderService.GetOrder();
            var form = deliveryService.FirstForm(order);
            var webContractorService = webContractorServices.SingleOrDefault(service => service.Name == serviceName);
            if (webContractorService == null)
                return View("DeliveryStep", form);
            var returnUri = GetReturnUri(nameof(NextDelivery));
            var redirectUri = webContractorService.StartSession(form.Parameters, returnUri);
            return Redirect(redirectUri.ToString());

        }
        private Uri GetReturnUri(string action)
        {
            var builder = new UriBuilder(Request.Scheme, Request.Host.Host)
            {
                Path = Url.Action(action),
                Query = null,
            };
            if (Request.Host.Port != null)
                builder.Port = Request.Host.Port.Value;
            return builder.Uri;

        }
        [HttpPost]
        public IActionResult NextDelivery(string serviceName, int step, Dictionary<string, string> values)
        {
            var deliveryService = deliveryServices.Single(service => service.Name == serviceName);
            var form = deliveryService.NextForm(step, values);
            if (!form.IsFinal)
                return View("DeliveryStep", form);
            var delivery = deliveryService.GetDelivery(form);
            orderService.SetDelivery(delivery);
            var paymentMethods = paymentServices.ToDictionary(service => service.Name,
                                                            service => service.Title);
            return View("PaymentMethod", paymentMethods);
        }


        [HttpPost]
        public IActionResult StartPayment(string serviceName)
        {
            var paymentService = paymentServices.Single(service => service.Name == serviceName);
            var order = orderService.GetOrder();
            var form = paymentService.FirstForm(order);

            var webContractorService = webContractorServices.SingleOrDefault(service => service.Name == serviceName);
            if (webContractorService == null)
                return View("PaymentStep", form);
            var returnUri = GetReturnUri(nameof(NextPayment));
            var redirectUri = webContractorService.StartSession(form.Parameters, returnUri);
            return Redirect(redirectUri.ToString());

        }
        [HttpPost]
        public IActionResult NextPayment(string serviceName, int step, Dictionary<string, string> values)
        {
            var paymentService = paymentServices.Single(service => service.Name == serviceName);
            var form = paymentService.NextForm(step, values);
            if (!form.IsFinal)
                return View("PaymentStep", form);
           
            var payment = paymentService.GetPayment(form);
            var model = orderService.SetPayment(payment);
            return View("Finish", model);
       
        }

    }           
}
