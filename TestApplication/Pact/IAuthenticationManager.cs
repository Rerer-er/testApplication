using Entities.Models;
using Entities.ModelsDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pact
{
    public interface IAuthenticationManager
    {
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<string> CreateToken();
        Task<ICollection<string>> GetRoles(string user);
        
    }
}
