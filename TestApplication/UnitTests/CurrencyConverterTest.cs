using ActionDB;
using Entities.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Xunit;

namespace UnitTests
{
    public class CurrencyConverterTest
    {
        private Dictionary<string, decimal> Currency;
        private CurrencyConverter _currencyConverter;
        private Product productTest = new Product { ProductId = 53, Name = "rwer", Price = 1000 };
        //IConfiguration
        public CurrencyConverterTest()
        {
            IConfiguration configuration;
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            configuration = builder.Build();

            _currencyConverter = new CurrencyConverter(configuration);
            XDocument xml = XDocument.Load(configuration["ConnectionStrings:currencyApi"]);
            Currency = new Dictionary<string, decimal>();
            Currency.Add("rub", 1);
            Currency.Add("usd", Convert.ToDecimal(xml.Elements("ValCurs").Elements("Valute").FirstOrDefault(x => x.Element("NumCode").Value == "840").Elements("Value").FirstOrDefault().Value));
            Currency.Add("eur", Convert.ToDecimal(xml.Elements("ValCurs").Elements("Valute").FirstOrDefault(x => x.Element("NumCode").Value == "978").Elements("Value").FirstOrDefault().Value));
            Currency.Add("byn", Convert.ToDecimal(xml.Elements("ValCurs").Elements("Valute").FirstOrDefault(x => x.Element("NumCode").Value == "933").Elements("Value").FirstOrDefault().Value));
        }
        [Theory]
        [InlineData("rub")]
        [InlineData("eur")]
        [InlineData("usd")]
        [InlineData("byn")]
        private void ConvertToCurrent(string currency)
        {
            //Arrange
            decimal finalPrice = productTest.Price / Currency[currency];
            //Act
            _currencyConverter.ConvertToCurrent(productTest, currency);
            //Assert
            Xunit.Assert.Equal(Math.Round(finalPrice,2), productTest.Price);
        }

        [Theory]
        [InlineData("rub", 34.07)]
        [InlineData("eur", 33)]
        [InlineData("usd", 100)]
        [InlineData("byn", 1000)]
        private void ConvertToCurrentForFiltr(string currency, decimal price)
        {
            //Arrange
            decimal finalPrice = price * Currency[currency];
            //Act
            decimal newPrice = _currencyConverter.ConvertToCurrentForFiltr(price, currency);
            //Assert
            Xunit.Assert.Equal(Math.Round(finalPrice, 2), newPrice);
        }

        //[Fact]


        //[Theory]
        //[InlineData("rub")]
        //private void ConvertToCurrentForFiltrTest(string currency)
        //{
        //    //Arrange
        //    decimal finalPrice = productTest.Price / _currencyConverter.ReturnCurrencyValue(currency);
        //    //Act
        //    //_configuration.Setup(repo => repo.Shipper.GetAllShippersAsync(It.IsAny<bool>())).Returns(GetTestShippers());
        //    _currencyConverter.ConvertToCurrent(productTest, currency);

        //    //Assert

        //    Xunit.Assert.Equal(1, 1);
        //}
    }
}
