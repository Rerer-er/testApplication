using ActionDB;
using Entities;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace TestsRepository
{
    public class ProductActionsDBTest
    {
        private ApplicationContext _context;
        private AllModelsActions _actions;
        public ProductActionsDBTest()
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
        [Theory]
        [InlineData("0aaf0b40-aa62-441c-9637-47d8de830e23", false)]
        [InlineData("0aaf0b40-aa62-441c-9637-47d8de830e23", true)]
        //[InlineData()]
        public async Task GetsProductsBasketAsyncTest(string userId, bool trackChange)
        {
            var list = await _actions.Basket.GetsProductsBasketAsync(userId, trackChange);
            Assert.NotNull(list);
            Assert.NotEmpty(list);
        }
        [Theory]
        [InlineData(68, "0aaf0b40-aa62-441c-9637-47d8de830e23")]
        public async Task CreateProductBasketTest(int productId, string userId) /// не закончил 
        {
            ProductBasket productBasket = new ProductBasket() { Count = 1, ProductId = productId, UserId = userId };
            _actions.Basket.CreateProductBasket(productBasket);
            await _actions.SaveAsync();
            var returnProducts = await _actions.Basket.GetsProductsBasketAsync(userId, false);
            Assert.NotNull(returnProducts);
            //Assert.Contains<ProductBasket>(productBasket, returnProducts);
        }

        [Theory]
        [InlineData(68, "0aaf0b40-aa62-441c-9637-47d8de830e23")]
        public async Task DeleteProductBasketTest(int productId, string userId)/// не закончил 
        {
            ProductBasket productBasket = new ProductBasket() { Count = 1, ProductId = productId, UserId = userId };
            _actions.Basket.CreateProductBasket(productBasket);
            await _actions.SaveAsync();

            var returnProducts = await _actions.Basket.GetsProductsBasketAsync(userId, false);
            Assert.NotNull(returnProducts);

        }

        //Assert.NotEqual(0, list1.Count)
        //repository.Setup(x => x.ReturnAll(It.IsAny<bool>()))
        //    .Returns((int i) => bookInMemoryDatabase.Single(bo => bo.Id == i));
        //var mockSetProducts = new Mock<DbSet<Product>>();

        //mockContext.Setup(m => m.Products).Returns(mockSetProducts.Object);

        //var service = new ProductActionsDB(mockContext.Object);
        //service.CreateProduct(GetProduct().KindId, GetProduct());

        //mockSetProducts.Verify(m => m.Add(It.IsAny<Product>()), Times.Once());
        //mockContext.Verify(m => m.SaveChanges(), Times.Once());
    }
}
