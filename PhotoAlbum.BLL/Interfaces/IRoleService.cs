using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using PhotoAlbum.BLL.Dtos;

namespace PhotoAlbum.BLL.Interfaces
{
    public interface IRoleService : IDisposable
    {
        RoleDto FindById(int roleId);
        Task<RoleDto> FindByIdAsync(int roleId);
        Task<IdentityResult> CreateAsync(string roleName);
        Task<IdentityResult> DeleteAsync(int roleId);
        Task<IdentityResult> UpdateAsync(int roleId);
        Task<IEnumerable<RoleDto>> GetAllAsync();
    }
}
