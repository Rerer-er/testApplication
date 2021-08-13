using Entities;
using Entities.Models;
using Pact;
using System;
using System.Collections.Generic;
using System.Text;

namespace ActionDB
{
    public class ProductBasketActionsDB : BaseActionDB<ProductBasket>, IProductBasketActionsDB
    {
        public ProductBasketActionsDB(ApplicationContext context) : base(context)
        {

        }

    }
}
