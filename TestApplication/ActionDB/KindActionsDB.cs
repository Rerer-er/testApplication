using Entities;
using Entities.Models;
using Pact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActionDB
{
    public class KindActionsDB : BaseActionDB<Kind> , IKindActionsDB
    {
        public KindActionsDB(ApplicationContext context) : base(context)
        {

        }
        public IEnumerable<Kind> GetAllKinds(bool trackChange) => ReturnAll(trackChange).ToList();
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
 