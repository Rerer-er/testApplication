using Entities.ModelsDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pact
{
    public interface IAuthenticationManager
    {
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<string> CreateToken();

    }
}
