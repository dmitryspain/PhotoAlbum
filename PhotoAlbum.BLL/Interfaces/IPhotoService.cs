using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.BLL.Dtos;

namespace PhotoAlbum.BLL.Interfaces
{
    public interface IPhotoService : IDisposable
    {
        Task UploadPhotoAsync(int userId, byte[] data, string description);
        IEnumerable<PhotoDto> GetAllPhotos();
        void RemovePhoto(int photoId);
        Task<IEnumerable<PhotoDto>> GetAllPhotosAsync();
        Task<IEnumerable<PhotoDto>> GetUserPhotosAsync(int userId);
        Task<PhotoDto> GetPhotoByIdAsync(int photoId);
        Task LikeAsync(int photoId, int userId);
    }
}
