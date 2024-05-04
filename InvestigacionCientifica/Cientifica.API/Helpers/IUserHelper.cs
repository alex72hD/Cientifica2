using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Cientifica.Shared.Entities;
using Cientifica.API.Data;
namespace Cientifica.API.Helpers
{
    public interface IUserHelper
    {

        Task<Investigador> GetUserAsync(string email);
        Task<IdentityResult> AdduserAsync(Investigador user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(Investigador user, string roleName);

        Task<bool> IsUserInRoleAsync(Investigador user, string roleName);
    }
}
