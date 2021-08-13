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
            await ReturnDistinct(c => c.UserId.Equals(userId), trackChange).ToListAsync();

        public void CreateProductBasket(ProductBasket busket)
        {
            Create(busket);
        }
    }
}
