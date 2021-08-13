
using Entities;
using Pact;
using System.Threading.Tasks;

namespace ActionDB
{
    public class AllModelsActions : IAllModelsActions
    {
        private ApplicationContext context;


        private IProductActionsDB product;
        private IKindActionsDB kind;
        private IShipperActionsDB shipper;
        private IProductBasketActionsDB basket;

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
        public IProductBasketActionsDB Basket
        {
            get
            {
                if (basket == null)
                    basket = new ProductBasketActionsDB(context);
                return basket;
            }
        }
        public async Task SaveAsync() => await context.SaveChangesAsync();
    }
}
