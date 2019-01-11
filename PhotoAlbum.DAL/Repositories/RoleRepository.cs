using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using PhotoAlbum.DAL.EF;
using PhotoAlbum.DAL.Interfaces.IRepository;
using PhotoAlbum.DAL.Repositories.Base;
using PhotoAlbum.DAL.Entities;
using PhotoAlbum.DAL.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PhotoAlbum.DAL.Entities.Identity;

namespace PhotoAlbum.DAL.Repositories
{
    public class RoleRepository : BaseRepository<ApplicationRole>, IRoleRepository
    {
        private AppRoleManager _roleManager;

        public RoleRepository(PhotoAlbumContext context)
            : base(context)
        {
            _roleManager = new AppRoleManager(new CustomRoleStore(context));
        }

        public async Task<IdentityResult> CreateAsync(ApplicationRole role)
        {
            return await _roleManager.CreateAsync(role);
        }

        public async Task<IdentityResult> DeleteAsync(ApplicationRole role)
        {
            return await _roleManager.DeleteAsync(role);
        }

        public ApplicationRole FindById(int roleId)
        {
            return _roleManager.FindById(roleId);
        }

        public async Task<ApplicationRole> FindByIdAsync(int roleId)
        {
            return await _roleManager.FindByIdAsync(roleId);
        }

        public ApplicationRole FindByName(string roleName)
        {
            return _roleManager.FindByName(roleName);
        }

        public async Task<ApplicationRole> FindByNameAsync(string roleName)
        {
            return await _roleManager.FindByNameAsync(roleName);
        }

        public bool RoleExists(string roleName)
        {
            return _roleManager.RoleExists(roleName);
        }

        public async Task<bool> RoleExistsAsync(string roleName)
        {
            return await _roleManager.RoleExistsAsync(roleName);
        }
    }
}
