using AutoMapper;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Pact;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Controllers;
using Xunit;

namespace UnitTests
{
    public class ProductTest
    {
        private readonly HttpClient _client;
        private readonly Mock<ILoggerManager> loggerManager;
        private readonly Mock<IAllModelsActions> modelsActions;
        private readonly Mock<IMapper> mapper;
        private readonly Mock<ICurrencyConverter> currencyConverter;
        private ProductsController controller;
        private ProductParameters productParametrs;
        public ProductTest()
        {
            loggerManager = new Mock<ILoggerManager>();
            modelsActions = new Mock<IAllModelsActions>();
            mapper = new Mock<IMapper>();
            currencyConverter = new Mock<ICurrencyConverter>();
            controller = new ProductsController(loggerManager.Object, modelsActions.Object, mapper.Object, currencyConverter.Object);
            productParametrs = new ProductParameters();
        }
        private async Task<PagedList<Product>> GetTestProducts()
        {
            var products = new PagedList<Product>
            (
                new List<Product>()
                    {
                        new Product { ProductId =50, Name = "rwer", Price = 3000,},
                        new Product { ProductId =51, Name = "rwer", Price = 3000,},
                        new Product { ProductId =52, Name = "rwer", Price = 3000,},
                        new Product { ProductId =53, Name = "rwer", Price = 3000,}
                    },
                4, 1, 1
            );
            return products;
        }
        private async Task<Product> GetTestProduct()
        {
            return new Product { ProductId = 50, Name = "rwer", Price = 3000, };
        }
        [Fact]
        public async Task Get_Products_AllAsync()
        {
            //Arrange
            modelsActions.Setup(repo => repo.Product.GetAllProductsAsync(It.IsAny<int>(), It.IsAny<ProductParameters>(), It.IsAny<bool>())).Returns(GetTestProducts());
            // Act
            var result = await controller.GetProducts(1, productParametrs);
            //Assert
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
        }
        [Theory]
        [InlineData(1,1,"rub")]
        [InlineData(2,1,"rub")]
        [InlineData(5,1,"rub")]
        [InlineData(6,1,"rub")]
        public async Task Get_Product_Async(int kindId, int productId, string currency)
        {
            //Arrange
            modelsActions.Setup(repo => repo.Product.GetProductAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<bool>())).Returns(GetTestProduct());
            // Act
            var result = await controller.GetProduct(kindId, productId, currency);
            //Assert
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
        }
        //[Theory]
        //[InlineData(1, 1, "rub")]
        //public async Task Create_Product(int kindId, int productId, string currency)
        //{
        //    //Arrange
        //    //modelsActions.Setup(repo => repo.Product.CreateProduct(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<bool>())).Returns(GetTestProduct());
        //    // Act
        //    var result = await controller.GetProduct(kindId, productId, currency);
        //    //Assert
        //    var okResult = result as OkObjectResult;
        //    Assert.NotNull(okResult);
        //}
    }
}


