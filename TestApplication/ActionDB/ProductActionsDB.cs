
using ActionDB.Extensions;
using Entities;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Pact;
using System.Linq;
using System.Threading.Tasks;

namespace ActionDB
{
    public class ProductActionsDB : BaseActionDB<Product>, IProductActionsDB
    {
        public ProductActionsDB(ApplicationContext context) : base(context)
        {
        }
        // todo: maybe, maybe there is an error in this code(check all classes)(0 => 3500)
        public async Task<PagedList<Product>> GetAllProductsAsync(int kindId, ProductParameters productParameters, bool trackChange)
        {
            var products = await ReturnDistinct(e => (e.KindId.Equals(kindId)), trackChange).Include(u => u.Shipper)
                .FilterProduct(productParameters.MinPrice, productParameters.MaxPrice)
                .Search(productParameters.SearchTerm).OrderBy(e => e.Name)
                .Sort(productParameters.OrderBy).ToListAsync();

            return PagedList<Product>.ToPagedList(products, productParameters.PageNumber,
            productParameters.PageSize);
        }
        public async Task<Product> GetProductAsync(int kindId, int productId, bool trackChange) =>
            await ReturnDistinct(c => c.ProductId.Equals(productId) && c.KindId.Equals(kindId), trackChange).SingleOrDefaultAsync();

        public Product GetProduct(int kindId, int productId, bool trackChange) =>
           ReturnDistinct(c => c.ProductId.Equals(productId) && c.KindId.Equals(kindId), trackChange).SingleOrDefault();

        public void CreateProduct(int kindId, Product product)
        {
            product.KindId = kindId;
            Create(product);
        }
        public void DeleteProduct(Product product)
        {
            Delete(product);
        }

    }
}
