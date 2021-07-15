//using Entities.Сurrency;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Pact;
using ActionDB;
namespace TestApplication.Currency
{
    public class CurrencyService
    {
        //private readonly IMemoryCache memoryCache;
        private ICurrencyConverter currencyConverter;
        public CurrencyService(ICurrencyConverter _currencyConverter)
        {
            currencyConverter = _currencyConverter; 
        }
        public void Parse()
        {
            XDocument xml = XDocument.Load("http://www.cbr.ru/scripts/XML_daily.asp");
            //currencyConverter.Add("usd", Convert.ToDecimal(xml.Elements("ValCurs").Elements("Valute").FirstOrDefault(x => x.Element("NumCode").Value == "840").Elements("Value").FirstOrDefault().Value));
            //currencyConverter.Add("eur", Convert.ToDecimal(xml.Elements("ValCurs").Elements("Valute").FirstOrDefault(x => x.Element("NumCode").Value == "978").Elements("Value").FirstOrDefault().Value));
            //currencyConverter.Add("byn", Convert.ToDecimal(xml.Elements("ValCurs").Elements("Valute").FirstOrDefault(x => x.Element("NumCode").Value == "933").Elements("Value").FirstOrDefault().Value));
        }

        //protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        //{
            

                  


        //            XDocument xml = XDocument.Load("http://www.cbr.ru/scripts/XML_daily.asp");


        //           // CurrencyConverter currencyConverter = new CurrencyConverter();

        //            currencyConverter.Add("usd", Convert.ToDecimal(xml.Elements("ValCurs").Elements("Valute").FirstOrDefault(x => x.Element("NumCode").Value == "840").Elements("Value").FirstOrDefault().Value));
        //            currencyConverter.Add("eur", Convert.ToDecimal(xml.Elements("ValCurs").Elements("Valute").FirstOrDefault(x => x.Element("NumCode").Value == "978").Elements("Value").FirstOrDefault().Value));
        //            currencyConverter.Add("byn", Convert.ToDecimal(xml.Elements("ValCurs").Elements("Valute").FirstOrDefault(x => x.Element("NumCode").Value == "933").Elements("Value").FirstOrDefault().Value));




        //            //currencyConverter.Currency.Add("rub", Convert.ToDecimal(xml.Elements("ValCurs").Elements("Valute").FirstOrDefault(x => x.Element("NumCode").Value == "810").Elements("Value").FirstOrDefault().Value));

        //            //currencyConverter.USD = Convert.ToDecimal(xml.Elements("ValCurs").Elements("Valute").FirstOrDefault(x => x.Element("NumCode").Value == "840").Elements("Value").FirstOrDefault().Value);
        //            //currencyConverter.EUR = Convert.ToDecimal(xml.Elements("ValCurs").Elements("Valute").FirstOrDefault(x => x.Element("NumCode").Value == "978").Elements("Value").FirstOrDefault().Value);
        //            //currencyConverter.BYN = Convert.ToDecimal(xml.Elements("ValCurs").Elements("Valute").FirstOrDefault(x => x.Element("NumCode").Value == "933").Elements("Value").FirstOrDefault().Value);
                    

        //            //memoryCache.Set("key_currency", currencyConverter, TimeSpan.FromMinutes(1440));

            
        //}
    }
}
