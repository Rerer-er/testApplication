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
    public class KindActionsDBTest
    {
        private ApplicationContext _context;
        private AllModelsActions _actions;
        public KindActionsDBTest()
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
        [InlineData(false)]
        [InlineData(true)]
        public async Task GetAllKindAsyncTest(bool trackChange)
        {
            var list = await _actions.Kind.GetAllKindsAsync(new KindParameters() { PageSize = 50 }, trackChange);
            Assert.NotNull(list);
            Assert.NotEmpty(list);
        }
        [Theory]
        [InlineData(1, false)]
        [InlineData(1, true)]
        [InlineData(2, true)]
        public async Task GetKindAsyncTest(int kindId, bool trackChange)
        {
            var kind = await _actions.Kind.GetKindAsync(kindId, trackChange);

            Assert.NotNull(kind);
        }
        [Theory]
        [InlineData(1, false)]
        [InlineData(1, true)]
        [InlineData(2, false)]

        public void GetKindTest(int kindId, bool trackChange)
        {
            var kind = _actions.Kind.GetKind(kindId, trackChange);

            Assert.NotNull(kind);
        }

        [Fact]
        public async Task CreateKindTest()
        {
            Kind kind = new Kind() { Name = "test product", About = "test product", Foto = "dsf" };
            _actions.Kind.CreateKind(kind);
            await _actions.SaveAsync();

            var returnProduct = await _actions.Kind.GetKindAsync(kind.KindId, false);

            Assert.NotNull(returnProduct);
        }

        [Fact]
        public async Task DeleteKindTest()
        {
            Kind kind = new Kind() { Name = "test product", About = "test product", Foto = "dsf" };
            _actions.Kind.CreateKind(kind);
            await _actions.SaveAsync();

            var returnProduct = await _actions.Kind.GetKindAsync(kind.KindId, false);
            _actions.Kind.DeleteKind(kind);
            await _actions.SaveAsync();

            var deleteProduct = await _actions.Kind.GetKindAsync(kind.KindId, false);
            Assert.Null(deleteProduct);
        }

    }
}
