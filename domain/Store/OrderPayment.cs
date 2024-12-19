﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class OrderPayment
    {
        public string UniqueCode { get; }   
        public string Description { get; }
        public IReadOnlyDictionary<string,string> Parameters { get; }
        public OrderPayment(string uniqueCode, string description, IReadOnlyDictionary<string, string> parameters)
        {
            
            UniqueCode = uniqueCode;
            Description = description;
           
            Parameters = parameters;
        }       
    }
}
