using Store.data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
	public class OrderItemCollection:IReadOnlyCollection<OrderItem>
	{
        private readonly OrderDto orderDto;
        private readonly List<OrderItem> items;

        public OrderItemCollection(OrderDto orderDto)
        {
            if(orderDto == null)
                throw new ArgumentNullException(nameof(orderDto));
            this.orderDto = orderDto;

            items = orderDto.Items
                            .Select(OrderItem.Mapper.Map)
                            .ToList();
        }
        public int Count => items.Count;
        public OrderItem Get(int bookId)
        {
            if (TryGet(bookId, out OrderItem orderItem))
                return orderItem;

            throw new InvalidOperationException("Book not found.");
        }
        public bool TryGet(int bookId, out OrderItem orderItem)
        {
            var index = items.FindIndex(item => item.ProductId == bookId);
            if (index == -1)
            {
                orderItem = null;
                return false;
            }

            orderItem = items[index];
            return true;
        }
        public IEnumerator<OrderItem> GetEnumerator()
		{
			return items.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return (items as IEnumerator<OrderItem>);
		}
		public OrderItem Add(int productid,decimal productPrice,string name,int count)
		{
			if(TryGet(productid,out OrderItem orderitem))
			{
				throw new InvalidOperationException();
            }
            var orderItemDto = OrderItem.DtoFactory.Create(orderDto, productid, productPrice, count);
            orderDto.Items.Add(orderItemDto);

            orderitem = OrderItem.Mapper.Map(orderItemDto);
            items.Add(orderitem);
			return orderitem;
		}
		public void Remove(int productid)
		{
            var index = items.FindIndex(item => item.ProductId == productid);
            if (index == -1)
                throw new InvalidOperationException("Can't find book to remove from order.");

            orderDto.Items.RemoveAt(index);
            items.RemoveAt(index);

        }
	}
}
