using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.BLL.Dtos;

namespace PhotoAlbum.BLL.Interfaces
{
    public interface IRoleService : IDisposable
    {
        Task<IEnumerable<RoleDto>> GetAllRolesAsync();
        Task<IEnumerable<RoleDto>> GetAllRolesAsync(Expression<Func<RoleDto, bool>> expression);
        Task<RoleDto> GetSingleAsync(Expression<Func<RoleDto, bool>> expression);
    }
}
