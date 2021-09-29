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
    public class ProductBasketActions
    {
        private ApplicationContext _context;
        private AllModelsActions _actions;
        public ProductBasketActions()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json");

            IConfiguration configuration;
            configuration = builder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("sqlConnection"));

            _context = new ApplicationContext(optionsBuilder.Options);

            _actions = new AllModelsActions(_context);
        }
        [Theory]
        [InlineData(1, false)]
        [InlineData(2, true)]
        public async Task GetAllProductsAsyncTest(int kindId, bool trackChange)
        {
            var list = await _actions.Product.GetAllProductsAsync(kindId, new ProductParameters() { PageSize = 50 }, trackChange);
            Assert.NotNull(list);
            Assert.NotEmpty(list);
        }
        [Theory]
        [InlineData(1, 4, false)]
        [InlineData(1, 4, true)]
        [InlineData(2, 2, true)]
        public async Task GetProductAsyncTest(int kindId, int productId, bool trackChange)
        {
            var product = await _actions.Product.GetProductAsync(kindId, productId, trackChange);

            Assert.NotNull(product);
        }
        [Theory]
        [InlineData(1, 4, false)]
        [InlineData(1, 4, true)]
        [InlineData(2, 2, true)]
        public void GetProductTest(int kindId, int productId, bool trackChange)
        {
            var product = _actions.Product.GetProduct(kindId, productId, trackChange);

            Assert.NotNull(product);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 1)]
        public async Task CreateProductTest(int kindId, int shipperId)
        {
            Product product = new Product() { Name = "test product", About = "test product", ShipperId = shipperId, Foto = "dsf", Price = 300, };
            _actions.Product.CreateProduct(kindId, product);
            await _actions.SaveAsync();
            var returnProduct = await _actions.Product.GetProductAsync(kindId, product.ProductId, false);

            Assert.NotNull(returnProduct);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 1)]
        public async Task DeleteProductTest(int kindId, int shipperId)
        {
            Product product = new Product() { Name = "test product", About = "test product", ShipperId = shipperId, Foto = "dsf", Price = 300, };
            _actions.Product.CreateProduct(kindId, product);
            await _actions.SaveAsync();

            var returnProduct = await _actions.Product.GetProductAsync(kindId, product.ProductId, false);
            _actions.Product.DeleteProduct(product);
            await _actions.SaveAsync();
            var deleteProduct = await _actions.Product.GetProductAsync(kindId, product.ProductId, false);
            Assert.Null(deleteProduct);
        }
    }
}

