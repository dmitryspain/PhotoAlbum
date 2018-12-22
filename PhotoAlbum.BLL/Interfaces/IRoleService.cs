using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using PhotoAlbum.BLL.Dtos;

namespace PhotoAlbum.BLL.Interfaces
{
    public interface IRoleService : IDisposable
    {
        Task<RoleDto> FindByIdAsync(int roleId);
        Task<IdentityResult> CreateAsync(string roleName);
        Task<IdentityResult> DeleteAsync(int roleId);
        IQueryable<RoleDto> Roles { get; }
        Task<IdentityResult> UpdateAsync(int roleId);
        Task<IEnumerable<RoleDto>> GetAllAsync();
    }

//    Create(role) / CreateAsync(role) : создает новую роль с именем role
//• Delete(role) / DeleteAsync(role) : удаляет роль с именем role
//• FindById(id) / FindByIdAsync(id) : ищет роль по id
//• FindByName(name) / FindByNameAsync(name) : ищет роль по названию
//• RoleExists(name) / RoleExistsAsync(name) : возвращает true, если роль с данным
//названием существует
//• Update(role) / UpdateAsync(role) : обновляет роль
//• Roles: возвращает набор всех имеющихся ролей
}
