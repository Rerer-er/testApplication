using AutoMapper;
using Entities.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Moq;
using Pact;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using TestApplication;
using TestApplication.Controllers;
using Xunit;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    public class ShipperTest
    {
        private readonly HttpClient _client;
        private readonly Mock<ILoggerManager> loggerManager;
        private readonly Mock<IAllModelsActions> modelsActions;
        private readonly Mock<IMapper> mapper;
        private readonly Mock<ICurrencyConverter> currencyConverter;


        public ShipperTest()
        {
            loggerManager = new Mock<ILoggerManager>();
            modelsActions = new Mock<IAllModelsActions>();
            mapper = new Mock<IMapper>();
            currencyConverter = new Mock<ICurrencyConverter>();


            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var webBuilder = new WebHostBuilder()
            .UseConfiguration(builder.Build())
            .UseStartup<Startup>();

            var server = new TestServer(webBuilder);

            _client = server.CreateClient();

            //Configuration = builder.Build();
        }

        private async Task<IEnumerable<Shipper>> GetTestShippers()
        {
            var shippers = new List<Shipper>
            {
                new Shipper { ShipperId =50, Name = "rwer"},
                new Shipper { ShipperId =51, Name = "rwer"},
                new Shipper { ShipperId =52, Name = "rwer"},
                new Shipper { ShipperId =53, Name = "rwer"}
            };
            return shippers;
        }
        [Fact]
        public async Task GetPublicHealthEndpoint()
        {
            var apiResponse = await _client.GetAsync("/kinds");
            Assert.Equal(StatusCodes.Status200OK, (int)apiResponse.StatusCode);
        }

        [Fact]
        public async Task Get_Shipper_AllAsync()
        {
            //Arrange
            var controller = new ShipperController(loggerManager.Object, modelsActions.Object, mapper.Object);
            modelsActions.Setup(repo => repo.Shipper.GetAllShippersAsync(It.IsAny<bool>())).Returns(GetTestShippers());//.ReturnsAsync((Shipper)null)
            // Act
            var result = await controller.GetShippers();
            //Assert
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
        }
    }
}
