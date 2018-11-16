using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.DAL.EF.Interfaces.IRepository;
using PhotoAlbum.DAL.EF.Repositories.Base;

namespace PhotoAlbum.DAL.EF.UoF.Base
{
    public interface IUnitOfWork : IDisposable
    {
        IGalleryRepository GalleryRepository { get; set; }
        IRoleRepository RoleRepository { get; set; }
        IUserRepository UserRepository { get; set; }
        IPhotoRepository PhotoRepository { get; set; }
        Task SaveAsync();
    }
}
