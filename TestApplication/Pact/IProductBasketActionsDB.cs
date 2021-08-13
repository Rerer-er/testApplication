using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pact
{
    public interface IProductBasketActionsDB
    {
        public Task<IEnumerable<ProductBasket>> GetsProductsBasketAsync(string userId, bool trackChange);

        public void CreateProductBasket(ProductBasket busket);
    }
}
