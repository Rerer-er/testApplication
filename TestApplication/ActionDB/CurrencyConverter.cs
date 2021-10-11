using Entities.Models;
using Microsoft.Extensions.Configuration;
using Pact;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Linq;

namespace ActionDB
{
    public class CurrencyConverter : ICurrencyConverter
    {
        private Dictionary<string, decimal> Currency;

        IConfiguration configuration { get; set; }

        public CurrencyConverter(IConfiguration _configuration)
        {
            configuration = _configuration;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-RU");
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            XDocument xml = XDocument.Load(configuration["ConnectionStrings:currencyApi"]);
            Currency = new Dictionary<string, decimal>();
            Currency.Add("rub", 1);
            Currency.Add("usd", Convert.ToDecimal(xml.Elements("ValCurs").Elements("Valute").FirstOrDefault(x => x.Element("NumCode").Value == "840").Elements("Value").FirstOrDefault().Value));
            Currency.Add("eur", Convert.ToDecimal(xml.Elements("ValCurs").Elements("Valute").FirstOrDefault(x => x.Element("NumCode").Value == "978").Elements("Value").FirstOrDefault().Value));
            Currency.Add("byn", Convert.ToDecimal(xml.Elements("ValCurs").Elements("Valute").FirstOrDefault(x => x.Element("NumCode").Value == "933").Elements("Value").FirstOrDefault().Value));
        }
        public decimal ReturnCurrencyValue(string currency)
        {

            if (Currency.ContainsKey(currency)) return this.Currency[currency];
            else return 1;
        }
        public decimal ConvertToCurrentForFiltr(decimal price, string currency)
        {

            if (!Currency.ContainsKey(currency)) return price;
            return Math.Round(price * Currency[currency], 2);
        }
        public void ConvertToCurrent(Product product, string currency)
        {

            if (!Currency.ContainsKey(currency)) return;
            product.Price = Math.Round(product.Price / Currency[currency], 2);
        }
    }
}
