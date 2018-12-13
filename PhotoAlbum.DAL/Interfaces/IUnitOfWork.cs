using System;
using System.Threading.Tasks;
using PhotoAlbum.DAL.Interfaces.IRepository;

namespace PhotoAlbum.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGalleryRepository GalleryRepository { get; set; }
        //IRoleRepository RoleRepository { get; set; }
        //IUserRepository UserRepository { get; set; }
        IPhotoRepository PhotoRepository { get; set; }
        Task SaveAsync();
    }
}
