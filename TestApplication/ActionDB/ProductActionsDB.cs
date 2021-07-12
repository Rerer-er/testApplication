using System;
using System.Collections.Generic;
using System.Text;

using Pact;
using Entities.Models;
using Entities;
using System.Linq;

namespace ActionDB
{
    public class ProductActionsDB : BaseActionDB<Product> , IProductActionsDB
    {
        public ProductActionsDB(ApplicationContext context) : base(context)
        {

        }
        public IEnumerable<Product> GetAllProducts(int kindId) =>
            ReturnDistinct(e => e.KindId.Equals(kindId)).ToList();
        public Product GetProduct(int kindId, int productId) => ReturnDistinct(c => c.ProductId.Equals(productId) && c.KindId.Equals(kindId)).SingleOrDefault();

        public void CreateProduct(int kindId, Product product)
        {
            product.KindId = kindId;
            Create(product);
        }

    }
}
