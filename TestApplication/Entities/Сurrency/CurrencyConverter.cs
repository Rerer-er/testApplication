using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Сurrency
{
    public class CurrencyConverter 
    {
        public Dictionary<string, decimal> Currency;
        public CurrencyConverter()
        {
            Currency = new Dictionary<string, decimal>();
            Currency.Add("rub", 1);
        }

        public void ConvertToCurrent(ICollection<Product> products, string currency)
        {
            if (!Currency.ContainsKey(currency)) return;
            foreach(var product in products)
            {
                product.Price = Math.Round(product.Price / Currency[currency], 2);
            }
        }
        public decimal USD { get; set; }
        public decimal ConvertToUSD(decimal priceRUB) => priceRUB / USD;

        public decimal EUR { get; set; }
        public decimal ConvertToEUR(decimal priceRUB) => priceRUB / EUR;
        
        public decimal BYN { get; set; }
        public decimal ConvertToBYN(decimal priceRUB) => priceRUB / BYN;


    }
}
