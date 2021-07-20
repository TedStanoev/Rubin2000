using Microsoft.AspNetCore.Identity;
using Rubin2000.Models;
using System.Security.Claims;

namespace Rubin2000.Services.ForClients
{
    public interface IUserService
    {
        AppUser GetUserById(string id);

        string GetUserId(ClaimsPrincipal user);
    }
}
