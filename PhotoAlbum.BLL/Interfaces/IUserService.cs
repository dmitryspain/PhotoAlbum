using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using PhotoAlbum.BLL.Dtos;

namespace PhotoAlbum.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        //Task<IEnumerable<UserDto>> GetAllUsersAsync();
        //Task<IEnumerable<UserDto>> GetAllUsersAsync(Expression<Func<UserDto, bool>> expression);
        //IEnumerable<UserDto> GetAllUsers();
        //Task<UserDto> GetSingleAsync(Expression<Func<UserDto, bool>> expression);

        Task<UserDto> FindAsync(string userName, string password);
        Task<UserDto> FindByIdAsync(string userId);
        Task<ClaimsIdentity> CreateIdentityAsync(UserDto user, string authenticationType);
        Task<IdentityResult> CreateAsync(UserDto userDto, string password);
        Task<IdentityResult> UpdateAsync(UserDto user);
        Task<IdentityResult> DeleteAsync(string userId);
        Task<IdentityResult> AddToRoleAsync(string userId, string role);
        Task<IdentityResult> RemoveFromRoleAsync(string userId, string role);
        Task<List<UserDto>> GetAllAsync();
        List<UserDto> GetAll();
        IQueryable<UserDto> Users { get; }
    }
}
