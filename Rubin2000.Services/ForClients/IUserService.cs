using Microsoft.AspNetCore.Identity;
using Rubin2000.Models;

namespace Rubin2000.Services.ForClients
{
    public interface IUserService
    {
        AppUser GetUserById(string id);
    }
}
