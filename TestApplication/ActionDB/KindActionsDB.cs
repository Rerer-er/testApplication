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
        public IEnumerable<Kind> GetAllKinds() => ReturnAll().ToList();
        public Kind GetKind(int kindId) => ReturnDistinct(c => c.KindId.Equals(kindId)).SingleOrDefault();
        
        void CreateKind(Kind kind)
        {
            Create(kind);
        }
    }
}
 