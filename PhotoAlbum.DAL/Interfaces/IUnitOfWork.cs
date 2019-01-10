using System;
using System.Threading.Tasks;
using PhotoAlbum.DAL.Interfaces.IRepository;

namespace PhotoAlbum.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPhotoRepository PhotoRepository { get; set; }
        IClientProfilesRepository ClientProfilesRepository { get; set; }
        ILikeRepository LikeRepository { get; set; }
        Task SaveAsync();
    }
}
