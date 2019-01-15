using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PhotoAlbum.DAL.EF;
using PhotoAlbum.DAL.Entities;
using PhotoAlbum.DAL.Entities.Identity;
using PhotoAlbum.DAL.Identity;
using PhotoAlbum.DAL.Interfaces.IRepository;
using PhotoAlbum.DAL.Repositories.Base;

namespace PhotoAlbum.DAL.Repositories
{
    public class UserRepository : BaseRepository<ApplicationUser>, IUserRepository
    {
        private AppUserManager _userManager;

        public UserRepository(PhotoAlbumContext context)
            : base(context)
        {
            _userManager = new AppUserManager(new UserStore<ApplicationUser, ApplicationRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>(context));
        }

        public async Task<IdentityResult> AddToRoleAsync(int userId, string role)
        {
            return await _userManager.AddToRoleAsync(userId, role);
        }

        public async Task<IList<string>> GetRolesAsync(int userId)
        {
            return await _userManager.GetRolesAsync(userId);
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<bool> IsInRoleAsync(int userId, string role)
        {
            return await _userManager.IsInRoleAsync(userId, role);
        }

        public async Task<ClaimsIdentity> CreateIdentityAsync(ApplicationUser user, string authenticationType)
        {
            return await _userManager.CreateIdentityAsync(user, authenticationType);
        }

        public async Task<IdentityResult> DeleteAsync(ApplicationUser user)
        {
            return await _userManager.DeleteAsync(user);
        }

        public async Task<ApplicationUser> FindAsync(string userName, string password)
        {
            return await _userManager.FindAsync(userName, password);
        }

        public async Task<ApplicationUser> FindByIdAsync(int userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<ApplicationUser> FindByNameAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public async Task<IdentityResult> RemoveFromRoleAsync(int userId, string role)
        {
            return await _userManager.RemoveFromRoleAsync(userId, role);
        }

        public async Task<IdentityResult> UpdateAsync(ApplicationUser user)
        {
            return await _userManager.UpdateAsync(user);
        }
    }
}
