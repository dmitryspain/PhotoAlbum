using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.BLL.Dtos;

namespace PhotoAlbum.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<IEnumerable<UserDto>> GetAllUsersAsync(Expression<Func<UserDto, bool>> expression);
        IEnumerable<UserDto> GetAllUsers();
        Task<UserDto> GetSingleAsync(Expression<Func<UserDto, bool>> expression);
    }
}
