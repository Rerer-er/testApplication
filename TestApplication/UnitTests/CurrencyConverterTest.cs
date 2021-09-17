using ActionDB;
using Entities.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Xunit;

namespace UnitTests
{
    public class CurrencyConverterTest
    {
        private readonly Mock<IConfiguration> _configuration;
        private CurrencyConverter _currencyConverter;
        private Product productTest = new Product { ProductId = 53, Name = "rwer", Price = 1000 };
        //IConfiguration
        public CurrencyConverterTest()
        {
            _configuration = new Mock<IConfiguration>();
            _currencyConverter = new CurrencyConverter(_configuration.Object);
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
