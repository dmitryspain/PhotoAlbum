using System;
using System.Threading.Tasks;
using PhotoAlbum.DAL.Interfaces.IRepository;

namespace PhotoAlbum.DAL.Interfaces
{
    public interface IIdentityUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IRoleRepository RoleRepository { get; }
        Task SaveAsync();
    }
}
