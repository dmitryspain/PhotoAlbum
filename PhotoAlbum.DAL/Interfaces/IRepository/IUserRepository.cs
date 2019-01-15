using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using PhotoAlbum.DAL.Entities;

namespace PhotoAlbum.DAL.Interfaces.IRepository
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        Task<ApplicationUser> FindAsync(string userName, string password);
        Task<ApplicationUser> FindByIdAsync(int userId);
        Task<ApplicationUser> FindByNameAsync(string userName);
        Task<IdentityResult> CreateAsync(ApplicationUser user, string password);
        Task<ClaimsIdentity> CreateIdentityAsync(ApplicationUser user, string authenticationType);
        Task<IdentityResult> UpdateAsync(ApplicationUser user);
        Task<IdentityResult> DeleteAsync(ApplicationUser user);
        Task<IdentityResult> AddToRoleAsync(int userId, string role);
        Task<bool> IsInRoleAsync(int userId, string role);
        Task<IdentityResult> RemoveFromRoleAsync(int userId, string role);
        Task<IList<string>> GetRolesAsync(int userId);
    }
}
