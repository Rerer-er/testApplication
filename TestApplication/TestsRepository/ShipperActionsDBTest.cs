using ActionDB;
using Entities;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace TestsRepository
{
    public class ShipperActionsDBTest
    {
        private ApplicationContext _context;
        private AllModelsActions _actions;
        public ShipperActionsDBTest()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json");

            IConfiguration configuration;
            var builder1 = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            configuration = builder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("sqlConnection"));
            _context = new ApplicationContext(optionsBuilder.Options);

            _actions = new AllModelsActions(_context);
        }
        [Fact]
        public async Task GetAllShipperAsyncTest()
        {
            var list = await _actions.Shipper.GetAllShippersAsync(false);
            Assert.NotNull(list);
            Assert.NotEmpty(list);
        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task GetShipperAsyncTest(int shipperId)
        {
            var shipper = await _actions.Shipper.GetShipperAsync(shipperId, false);

            Assert.NotNull(shipper);
        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void GetShipperTest(int shipperId)
        {
            var product = _actions.Shipper.GetShipper(shipperId, false);

            Assert.NotNull(product);
        }
        [Fact]
        //[Theory]
        //[InlineData()]
        public async Task CreateShipperTest()
        {
            Shipper shipper = new Shipper() { Name = "test product", Foto = "fds", LocationLat = 10, LocationLng = 12, FinalRating = 0, CountRating = 0, SumRating = 0  };
            _actions.Shipper.CreateShipper(shipper);
            await _actions.SaveAsync();
            var returnProduct = await _actions.Shipper.GetShipperAsync(shipper.ShipperId, false);

            Assert.NotNull(returnProduct);
        }

        [Fact]
        public async Task DeleteShipperTest()
        {
            Shipper shipper = new Shipper() { Name = "test product", Foto = "fds", LocationLat = 10, LocationLng = 12, FinalRating = 0, CountRating = 0, SumRating = 0 };
            _actions.Shipper.CreateShipper(shipper);
            await _actions.SaveAsync();

            var returnShipper = await _actions.Shipper.GetShipperAsync(shipper.ShipperId, false);
            _actions.Shipper.DeleteShipper(shipper);
            await _actions.SaveAsync();
            var deleteShipper = await _actions.Shipper.GetShipperAsync(shipper.ShipperId, false);
            Assert.Null(deleteShipper);
        }
    }
}
