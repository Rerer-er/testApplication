using System.Threading.Tasks;

namespace Pact
{
    public interface IAllModelsActions
    {
        IProductActionsDB Product { get; }
        IKindActionsDB Kind { get; }
        IShipperActionsDB Shipper { get; }
        Task SaveAsync();
    }
}
