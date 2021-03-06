﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using PhotoAlbum.BLL.Dtos;

namespace PhotoAlbum.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<UserDto> FindAsync(string userName, string password);
        Task<UserDto> FindByNameAsync(string userName);
        Task<UserDto> FindByIdAsync(int userId);
        Task<IdentityResult> CreateAsync(UserDto userDto, string password);
        Task<IdentityResult> UpdateAsync(UserDto user);
        Task<IdentityResult> DeleteAsync(int userId);
        Task<IdentityResult> AddToRoleAsync(int userId, string role);
        Task<IdentityResult> RemoveFromRoleAsync(int userId, string role);
        Task<List<UserDto>> GetAllAsync();
        List<UserDto> GetAll();
        Task<IList<string>> GetRolesAsync(int userId);
    }
}
