using Entities.Models;
using Entities.RequestFeatures;
using System.Threading.Tasks;

namespace Pact
{
    public interface IKindActionsDB
    {
        public Task<PagedList<Kind>> GetAllKindsAsync(KindParameters kindParameters, bool trackChange);

        public Task<Kind> GetKindAsync(int kindId, bool trackChange);
        public Kind GetKind(int kindId, bool trackChange);
        void CreateKind(Kind kind);
        void DeleteKind(Kind kind);
    }
}
