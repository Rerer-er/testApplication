using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pact
{
    public interface IOrderMicroservice
    {
        public void Publish(string message);
    }
}
