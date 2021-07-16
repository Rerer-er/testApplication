using Entities.Models;
using Entities.RequestFeatures;
using System.Threading.Tasks;

namespace Pact
{
    public interface IProductActionsDB
    {

        Task<PagedList<Product>> GetAllProductsAsync(int kindId, ProductParameters productParameters, bool trackChange);
        Task<Product> GetProductAsync(int kindId, int ProductId, bool trackChange);
        void CreateProduct(int kintId, Product product);
        public void DeleteProduct(Product product);
    }
}
