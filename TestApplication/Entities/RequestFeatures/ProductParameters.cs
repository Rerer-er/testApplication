using Entities.Сurrency;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.RequestFeatures
{
    public class ProductParameters : RequestParameters
    {
        public string Currency { get; set; } = "rub";
        public decimal MinPrice { get; set; } = 0;
        public decimal MaxPrice { get; set; } = 50000000;

        public string SearchTerm { get; set; }

        public bool ValidAgeRange => MaxPrice > MinPrice;

    }
    
}
