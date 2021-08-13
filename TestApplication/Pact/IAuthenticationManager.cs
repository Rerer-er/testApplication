using Entities.Models;
using Entities.ModelsDto;
using System.Threading.Tasks;

namespace Pact
{
    public interface IAuthenticationManager
    {
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<string> CreateToken();

        User GetUser();
    }
}
