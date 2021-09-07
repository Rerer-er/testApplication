using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pact
{
    public interface IOrderMicroservice
    {
        public Task Publish(string message);
    }
}
