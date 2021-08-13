using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Pact;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.RequestFeatures;
using ActionDB.Extensions;

namespace ActionDB
{
    public class KindActionsDB : BaseActionDB<Kind>, IKindActionsDB
    {
        public KindActionsDB(ApplicationContext context) : base(context)
        {

        }

        public async Task<PagedList<Kind>> GetAllKindsAsync(KindParameters kindParameters, bool trackChange)
        {
            var kinds = await ReturnAll(trackChange).Search(kindParameters.SearchTerm).ToListAsync();   
            return PagedList<Kind>.ToPagedList(kinds, kindParameters.PageNumber, kindParameters.PageSize);
        }
            //=> await ReturnAll(trackChange).ToListAsync();
        public async Task<Kind> GetKindAsync(int kindId, bool trackChange) => await ReturnDistinct(c => c.KindId.Equals(kindId), trackChange).SingleOrDefaultAsync();

        public Kind GetKind(int kindId, bool trackChange) => ReturnDistinct(c => c.KindId.Equals(kindId), trackChange).SingleOrDefault();
        public void CreateKind(Kind kind)
        {
            Create(kind);
        }
        public void DeleteKind(Kind kind)
        {
            Delete(kind);
        }
    }
}
