using ActionDB;
using AutoMapper;
using Entities;
using Entities.Models;
using Entities.ModelsDto;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using Pact;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using TestApplication;
using TestApplication.AutoMapper;
using TestApplication.Controllers;
using Xunit;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    public class ShipperTest
    {
        ShipperController controller;
        private readonly HttpClient _client;
        private readonly Mock<ILoggerManager> loggerManager;
        private readonly Mock<IAllModelsActions> modelsActions;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<ICurrencyConverter> currencyConverter;
        private readonly ShipperController shipperController;
        private ApplicationContext _context;
        public ShipperTest()
        {
            loggerManager = new Mock<ILoggerManager>();
            modelsActions = new Mock<IAllModelsActions>();
            _mapper = new Mock<IMapper>();
            currencyConverter = new Mock<ICurrencyConverter>();


            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var webBuilder = new WebHostBuilder()
            .UseConfiguration(builder.Build())
            .UseStartup<Startup>();

            var server = new TestServer(webBuilder);

            _client = server.CreateClient();

            var mapper = new MapperConfiguration(cnf =>
            {
                cnf.AddProfile(new MappingProfile());
            });
            var __mapper = mapper.CreateMapper();
            //Configuration = builder.Build();
            //DbContextOptions options = new DbContextOptions();
            IConfiguration configuration;
            var builder1 = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            configuration = builder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("sqlConnection"));
            _context = new ApplicationContext(optionsBuilder.Options); 
            
            shipperController = new ShipperController(loggerManager.Object, modelsActions.Object, __mapper);

            controller = new ShipperController(loggerManager.Object, modelsActions.Object, _mapper.Object);
            modelsActions.Setup(repo => repo.Shipper.GetAllShippersAsync(It.IsAny<bool>())).Returns(GetTestShippers());
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
        public async Task Get_Shipper_AllAsync()
        {
            //.ReturnsAsync((Shipper)null)
            // Act
            var result = await controller.GetShippers();
            //Assert
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
        }
        //[Fact]
        //public async Task Create_Shipper_Async()
        //{
        //    // Act
        //    var result = await controller.CreateShipper();
        //        new CreateProductDto() { Name = "test create product", About = "test", Foto = "qwe", Price = 400 });
        //    //Assert
        //    var objectResponse = Xunit.Assert.IsType<NoContentResult>(result);
        //    var okResult = result as OkObjectResult;
        //    Assert.NotNull(okResult);
        //}
        [Fact]
        public async Task Delete_Shipper_Async()
        {
            var random = new System.Random();
            //int randomId = random.Next(100, 1000);
            //Arrange
            modelsActions.Setup(repo => repo.Shipper.GetAllShippersAsync(It.IsAny<bool>())).Returns(GetTestShippers());//.ReturnsAsync((Shipper)null)
                                                                                                                       // Act

            //_mapper.Setup(repo => repo.(It.IsAny<bool>())).Returns(GetTestShippers());//.ReturnsAsync((Shipper)null)

            Shipper shipper;
            var result = await shipperController.CreateShipper(new CreateShipperDto() { Name = "testProduct"});
            var result1 = await shipperController.CreateShipper(new CreateShipperDto() { Name = "testProduct" });
            var result2 = await shipperController.CreateShipper(new CreateShipperDto() { Name = "testProduct" });
            var result3 = await shipperController.CreateShipper(new CreateShipperDto() { Name = "testProduct" });
            //var res = result.Value;
            //var objectResponse = Xunit.Assert.IsType<ObjectResult>(result);
            //var a = objectResponse.Value;
            //var objectResponse2 = Xunit.Assert.IsType<HttpResponseMessage>(result);
            //var objectResponse1 = Xunit.Assert.IsType<ObjectResult>(objectResponse);
            //objectResponse.TryGetContentValue<Shipper>(out shipper);

            //objectResponse
            //Assert
            //var okResult = result as OkObjectResult;
            var okResult = result as ObjectResult;
            var okResult1 = result1 as ObjectResult;
            var okResult2 = result2 as ObjectResult;
            var okResult3 = result3 as ObjectResult;
            //var actualShipper = okResult.Value as ReturnShipperDto;
            var a =1 ;
            //Assert.NotNull(okResult);
        }
    }
}
