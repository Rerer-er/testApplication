using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pact
{
    public interface IKindActionsDB
    {
        public Task<IEnumerable<Kind>> GetAllKindsAsync(bool trackChange);
        public Task<Kind> GetKindAsync(int kindId, bool trackChange);
        void CreateKind(Kind kind);
        void DeleteKind(Kind kind);
    }
}
