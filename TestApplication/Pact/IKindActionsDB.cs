using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.RequestFeatures;

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
