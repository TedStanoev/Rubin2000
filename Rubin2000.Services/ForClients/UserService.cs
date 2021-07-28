using Microsoft.AspNetCore.Identity;
using Rubin2000.Data;
using Rubin2000.Models;
using System.Linq;
using System.Security.Claims;

using static Rubin2000.Global.WebConstants;

namespace Rubin2000.Services.ForClients
{
    public class UserService : IUserService
    {
        private Rubin2000DbContext data;
        private UserManager<AppUser> userManager;

        public UserService(Rubin2000DbContext data, UserManager<AppUser> userManager)
        {
            this.data = data;
            this.userManager = userManager;
        }

        public AppUser GetUserById(string id)
            => (AppUser)this.data.Users
                .Where(u => u.Id == id)
                .FirstOrDefault();

        public string GetUserId(ClaimsPrincipal user)
            => this.userManager.GetUserId(user);

        public bool IsAdministrator(ClaimsPrincipal user)
            => user.IsInRole(AdminRole);
        
    }
}
