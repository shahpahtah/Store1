using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests
{
    public class OrderItemTests
    {
        [Fact]
        public void OrderItem_WithZeroCount_Throwargumentexception()
        {
            Assert.Throws<ArgumentException>(() => new OrderItem(1, 0, 12,"aaa"));
        }
    }
}
