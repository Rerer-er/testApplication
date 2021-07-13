using System;
using System.Collections.Generic;
using System.Text;

using Pact;
using Entities;
using Entities.Models;
using System.Threading.Tasks;

namespace ActionDB
{
    public class AllModelsActions : IAllModelsActions
    {
        private ApplicationContext context;


        private IProductActionsDB product;
        private IKindActionsDB kind;
        private IShipperActionsDB shipper;

        public AllModelsActions(ApplicationContext _context)
        {
            context = _context;
        }
        public IProductActionsDB Product
        {
            get
            {
                if (product == null)
                    product = new ProductActionsDB(context);
                return product;
            }
        }
        public IKindActionsDB Kind
        {
            get
            {
                if (kind == null)
                    kind = new KindActionsDB(context);
                return kind;
            }
        }
        public IShipperActionsDB Shipper
        {
            get
            {
                if (shipper == null)
                    shipper = new ShipperActionsDB(context);
                return shipper;
            }
        }
        public async Task SaveAsync() => await context.SaveChangesAsync();
    }
}
