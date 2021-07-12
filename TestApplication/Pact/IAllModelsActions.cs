using System;
using System.Collections.Generic;
using System.Text;

namespace Pact
{
    public interface IAllModelsActions
    {
        IProductActionsDB Product { get; }
        IKindActionsDB Kind { get; }
        void Save();
    }
}
