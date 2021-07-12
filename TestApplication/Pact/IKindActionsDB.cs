using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pact
{
    public interface IKindActionsDB
    {
        public IEnumerable<Kind> GetAllKinds();
        public Kind GetKind(int kindId);

        void CreateKind(Kind kind);
    }
}
