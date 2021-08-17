using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Pact;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ActionDB
{
    public class ProductBasketActionsDB : BaseActionDB<ProductBasket>, IProductBasketActionsDB
    {
        public ProductBasketActionsDB(ApplicationContext context) : base(context)
        {
        }
        public async Task<IEnumerable<ProductBasket>> GetsProductsBasketAsync(string userId,  bool trackChange) =>
            await ReturnDistinct(c => c.UserId.Equals(userId), trackChange).Include(p => p.Product).ToListAsync();

        public void CreateProductBasket(ProductBasket basket)
        {
            Create(basket);
        }
        public void DeleteProduct(ProductBasket basket)
        {
            Delete(basket);
        }
    }
}
