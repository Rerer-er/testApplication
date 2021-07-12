using System;
using System.Collections.Generic;
using System.Text;

using Entities.Models;

namespace Pact
{
    public interface IProductActionsDB
    {
        IEnumerable<Product> GetAllProducts(int kindId);
        Product GetProduct(int kindId, int ProductId);
        void CreateProduct(int kintId, Product product);
    }
}
