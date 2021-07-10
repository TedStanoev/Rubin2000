using Microsoft.AspNetCore.Identity;
using Rubin2000.Data;
using Rubin2000.Models;
using System.Linq;

namespace Rubin2000.Services.ForClients
{
    public class UserService : IUserService
    {
        private Rubin2000DbContext data;

        public UserService(Rubin2000DbContext data)
        {
            this.data = data;
        }

        public AppUser GetUserById(string id)
            => (AppUser)this.data.Users
                .Where(u => u.Id == id)
                .FirstOrDefault();
    }
}
