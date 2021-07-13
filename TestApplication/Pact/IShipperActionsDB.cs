using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pact
{
    public interface IShipperActionsDB
    {
        Task<IEnumerable<Shipper>> GetAllShippersAsync(int ShipperId, bool trackChange);
        Task<Shipper> GetShipperAsync(int SipperId, bool trackChange);
        void CreateShipper(int kintId, Shipper shipper);
        public void DeleteShipper(Shipper shipper);
    }
}
