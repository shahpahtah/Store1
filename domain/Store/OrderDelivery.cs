using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class OrderDelivery
    {
        public string UniqueCode { get; }   
        public string Description { get; }
        public decimal? Price{ get; }
        public IReadOnlyDictionary<string,string> Parameters { get; }
        public OrderDelivery(string uniqueCode, string description,decimal? amount, IReadOnlyDictionary<string, string> parameters)
        {
            
            UniqueCode = uniqueCode;
            Description = description;
            Price = amount;
            Parameters = parameters;
        }       
    }
}
