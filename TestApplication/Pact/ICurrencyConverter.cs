using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pact
{
    public interface ICurrencyConverter
    {
        decimal ConvertToCurrentForFiltr(decimal price, string currency);
        void ConvertToCurrent(Product products, string currency);
        public void UpdateCurrency();
    }
}
