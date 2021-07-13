using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Pact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionDB
{
    public class KindActionsDB : BaseActionDB<Kind> , IKindActionsDB
    {
        public KindActionsDB(ApplicationContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Kind>> GetAllKindsAsync(bool trackChange) => await ReturnAll(trackChange).ToListAsync();
        public async Task<Kind> GetKindAsync(int kindId, bool trackChange) => await ReturnDistinct(c => c.KindId.Equals(kindId), trackChange).SingleOrDefaultAsync();
        
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
 