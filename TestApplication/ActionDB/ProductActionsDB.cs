using System;
using System.Collections.Generic;
using System.Text;

using Pact;
using Entities.Models;
using Entities;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities.RequestFeatures;

namespace ActionDB
{
    public class ProductActionsDB : BaseActionDB<Product> , IProductActionsDB
    {
        public ProductActionsDB(ApplicationContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Product>> GetAllProductsAsync(int kindId, ProductParameters productParameters, bool trackChange) =>
            await ReturnDistinct(e => (e.KindId.Equals(kindId)), trackChange).OrderBy(p => p.Name)
            .Skip((productParameters.PageNumber - 1) * productParameters.PageSize)
            .Take(productParameters.PageSize).ToListAsync();
        public async Task<Product> GetProductAsync(int kindId, int productId, bool trackChange) => 
            await ReturnDistinct(c => c.ProductId.Equals(productId) && c.KindId.Equals(kindId), trackChange).SingleOrDefaultAsync();

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
