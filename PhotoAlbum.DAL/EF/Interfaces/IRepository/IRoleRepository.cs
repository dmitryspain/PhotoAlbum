using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.DAL.EF.Models;

namespace PhotoAlbum.DAL.EF.Interfaces.IRepository
{
    public interface IRoleRepository : IRepository<Role>
    {
        //AppRole FindByName(string roleName);
        //Task<AppRole> FindByNameAsync(string roleName);
        //Task<AppRole> FindByIdAsync(string roleId);
        //Task<IdentityResult> CreateAsync(AppRole role);
        //Task<IdentityResult> DeleteAsync(AppRole role);
        //bool RoleExists(string roleName);
        //Task<bool> RoleExistsAsync(string roleName);
    }
}
