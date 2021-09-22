using AutoMapper;
using Entities.Models;
using Entities.ModelsDto;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json.Linq;
using Pact;
using System;
using System.Collections.Generic;
using System.IO;
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
        public ProductTest()
        {
            loggerManager = new Mock<ILoggerManager>();
            modelsActions = new Mock<IAllModelsActions>();
            mapper = new Mock<IMapper>();
            currencyConverter = new Mock<ICurrencyConverter>();
            controller = new ProductsController(loggerManager.Object, modelsActions.Object, mapper.Object, currencyConverter.Object);
            productParametrs = new ProductParameters();
            modelsActions.Setup(repo => repo.Product.GetAllProductsAsync(It.IsAny<int>(), It.IsAny<ProductParameters>(), It.IsAny<bool>())).Returns(GetTestProducts());
            modelsActions.Setup(repo => repo.Product.GetProductAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<bool>())).Returns(GetTestProduct());
        }
        [Fact]
        public async Task Get_Products_AllAsync_Test()
        {
            //Arrange
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
        public async Task Get_Product_Async_Test(int kindId, int productId, string currency)
        {
            //Arrange
            // Act
            var result = await controller.GetProduct(kindId, productId, currency);
            //Assert
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
        }

        [Theory]
        [InlineData(1)]
        public async Task Create_Product_Test(int kindId)
        {
            // Act
            var result = await controller.CreateProduct(kindId, 
                new CreateProductDto() { Name = "test create product", About = "test", Foto = "qwe", Price = 400 });
            
            //Assert
            var objectResponse = Xunit.Assert.IsType<NoContentResult>(result);
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
        }
        [Theory]
        [InlineData(1,3)]
        public async Task Delete_Product_Test(int kindId, int productId)
        {
            // Act
            var result = await controller.DeleteProduct(kindId, productId);
            var objectResponse = Xunit.Assert.IsType<NoContentResult>(result);

            //Assert
            Assert.Equal(StatusCodes.Status204NoContent, objectResponse.StatusCode);
        }

        [Theory]
        [InlineData(1, 3)]
        public async Task Update_Product_Test(int kindId, int productId)
        {
            // Act
            var result = await controller.UpdateProduct(kindId, productId, new UpdateProductDto() { Name = "test create product", About = "test", Foto = "qwe", Price = 400 });
            var objectResponse = Xunit.Assert.IsType<NoContentResult>(result);

            //Assert
            Assert.Equal(StatusCodes.Status204NoContent, objectResponse.StatusCode);
        }
        //[Theory]
        //[InlineData(1, 3)]
        //public async Task Patch_Product_Test(int kindId, int productId)
        //{

        //    string str = "{ \"op\": \"replace\", \"path\": \"/name\", \"value\": \"new value\"}";
        //    TextReader r = new StringReader(str);

        //    //JObject json = JObject.Parse(str);
        //    var patch = new JsonPatchDocument<UpdateProductDto>();
        //    patch.Add()
        //    var patchProduct = new UpdateProductDto() { Name = "test create product", About = "test", Foto = "qwe", Price = 400 };

        //    // Act
        //    var result = await controller.PatchProduct(kindId, productId, patch);
        //    var objectResponse = Xunit.Assert.IsType<NoContentResult>(result);

        //    //Assert
        //    Assert.Equal(StatusCodes.Status204NoContent, objectResponse.StatusCode);
        //}
    }
}