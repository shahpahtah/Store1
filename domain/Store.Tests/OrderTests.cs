using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests
{
    public class OrderTests
    {
        [Fact]
        public void Order_argumentwithnullitems_throwargumentexception()
        {
            Assert.Throws<ArgumentNullException>(() => new Order(1, null));
        }
        [Fact]
        public void totalcount_withEmptyItems_returnzero()
        {
            var Order = new Order(1, new OrderItem[0]);
            Assert.Equal(0, Order.totalcount);
        }
        [Fact]
        public void totalcount_withNoEmptyItems_returntotalcountright()
        {
            var Order = new Order(1, new OrderItem[]
            {
                new OrderItem(1,3,10m, "aaa"),new OrderItem(2,5,100m, "aaa")
            });
            Assert.Equal(8, Order.totalcount);
        }
        [Fact]
        public void totalsum_withNoEmptyItems_returntotalcountright()
        {
            var Order = new Order(1, new OrderItem[]
            {
                new OrderItem(1,3,10m, "aaa"),new OrderItem(2,5,100m, "aaa")
            });
            Assert.Equal(530, Order.totalPrice);
        }
    }
}
