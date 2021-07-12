using Entities.Сurrency;
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
namespace TestApplication.Currency
{
    public class CurrencyService : BackgroundService
    {
        private readonly IMemoryCache memoryCache;

        public CurrencyService(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {

                    Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-RU");


                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);


                    XDocument xml = XDocument.Load("http://www.cbr.ru/scripts/XML_daily.asp");


                    CurrencyConverter currencyConverter = new CurrencyConverter();
                    currencyConverter.USD = Convert.ToDecimal(xml.Elements("ValCurs").Elements("Valute").FirstOrDefault(x => x.Element("NumCode").Value == "840").Elements("Value").FirstOrDefault().Value);
                    currencyConverter.EUR = Convert.ToDecimal(xml.Elements("ValCurs").Elements("Valute").FirstOrDefault(x => x.Element("NumCode").Value == "978").Elements("Value").FirstOrDefault().Value);
                    currencyConverter.BYN = Convert.ToDecimal(xml.Elements("ValCurs").Elements("Valute").FirstOrDefault(x => x.Element("NumCode").Value == "933").Elements("Value").FirstOrDefault().Value);
                    

                    memoryCache.Set("key_currency", currencyConverter, TimeSpan.FromMinutes(1440));
                }
                catch (Exception e)
                {
              
                }


                await Task.Delay(3600000, stoppingToken);
            }
        }
    }
}
