using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Pact;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ActionDB
{
    public class ShipperActionsDB : BaseActionDB<Shipper>, IShipperActionsDB
    {
        public ShipperActionsDB(ApplicationContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Shipper>> GetAllShippersAsync(bool trackChange) =>
            await ReturnAll(trackChange).ToListAsync();
        public async Task<Shipper> GetShipperAsync(int shipperId, bool trackChange) =>
            await ReturnDistinct(c => c.ShipperId.Equals(shipperId), trackChange).SingleOrDefaultAsync();

        public void CreateShipper(Shipper shipper)
        {
            //shipper.ShipperId = shipperId;
            Create(shipper);
        }
        public void DeleteShipper(Shipper shipper)
        {
            Delete(shipper);
        }
    }
}
