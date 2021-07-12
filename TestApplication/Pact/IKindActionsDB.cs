using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pact
{
    public interface IKindActionsDB
    {
        public IEnumerable<Kind> GetAllKinds(bool trackChange);
        public Kind GetKind(int kindId, bool trackChange);
        void CreateKind(Kind kind);
        void DeleteKind(Kind kind);
    }
}
