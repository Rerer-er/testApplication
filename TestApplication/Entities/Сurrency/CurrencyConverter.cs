using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Сurrency
{
    public class CurrencyConverter
    {
        public decimal USD { get; set; }
        public decimal ConvertToUSD(decimal priceRUB) => priceRUB / USD;

        public decimal EUR { get; set; }
        public decimal ConvertToEUR(decimal priceRUB) => priceRUB / EUR;
        
        public decimal BYN { get; set; }
        public decimal ConvertToBYN(decimal priceRUB) => priceRUB / BYN;


    }
}
