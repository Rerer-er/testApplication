using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pact
{
    public interface IProductActionsDB
    {
        Task<IEnumerable<Product>> GetAllProductsAsync(int kindId, bool trackChange);
        Task<Product> GetProductAsync(int kindId, int ProductId, bool trackChange);
        void CreateProduct(int kintId, Product product);
        public void DeleteProduct(Product product);
    }
}
