using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using PhotoAlbum.DAL.EF;
using PhotoAlbum.DAL.Interfaces.IRepository;
using PhotoAlbum.DAL.Repositories.Base;
using PhotoAlbum.DAL.Entities;

namespace PhotoAlbum.DAL.Repositories
{
    public class RoleRepository : BaseRepository<ApplicationRole>, IRoleRepository
    {
        public RoleRepository(PhotoAlbumContext context)
            : base(context)
        {
        }

        public Task<IdentityResult> CreateAsync(ApplicationRole role)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(ApplicationRole role)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationRole> FindByIdAsync(string roleId)
        {
            throw new NotImplementedException();
        }

        public ApplicationRole FindByName(string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationRole> FindByNameAsync(string roleName)
        {
            throw new NotImplementedException();
        }

        public bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RoleExistsAsync(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
