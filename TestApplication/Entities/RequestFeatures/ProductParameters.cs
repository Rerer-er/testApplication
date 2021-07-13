using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.RequestFeatures
{
    public class ProductParameters : RequestParameters
    {
        //public string Currency { get; set; } = "RUB";
        public decimal MinPrice { get; set; } = 0;
        public decimal MaxPrice { get; set; } = decimal.MaxValue;

        public bool ValidAgeRange => MaxPrice > MinPrice;

    }
    
}
