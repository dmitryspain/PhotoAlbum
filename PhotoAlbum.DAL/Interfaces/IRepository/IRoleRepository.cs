﻿using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using PhotoAlbum.DAL.Entities;

namespace PhotoAlbum.DAL.Interfaces.IRepository
{
    public interface IRoleRepository : IRepository<ApplicationRole>
    {
        ApplicationRole FindById(int roleId);
        ApplicationRole FindByName(string roleName);
        Task<ApplicationRole> FindByNameAsync(string roleName);
        Task<ApplicationRole> FindByIdAsync(int roleId);
        Task<IdentityResult> CreateAsync(ApplicationRole role);
        Task<IdentityResult> UpdateAsync(ApplicationRole role);
        Task<IdentityResult> DeleteAsync(ApplicationRole role);
        bool RoleExists(string roleName);
        Task<bool> RoleExistsAsync(string roleName);
    }
}
