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
        void UploadPhoto(PhotoDto photo);
        Task<IEnumerable<PhotoDto>> GetAllPhotosAsync();
        IEnumerable<PhotoDto> GetAllPhotos();
        void RemovePhoto(int photoId);
        Task<IEnumerable<PhotoDto>> GetUserPhotosAsync(int userId);
        Task<IEnumerable<PhotoDto>> GetAllPhotosAsync(Expression<Func<PhotoDto, bool>> expression);
        Task<PhotoDto> GetSingleAsync(Expression<Func<PhotoDto, bool>> expression);
        Task<PhotoDto> GetPhotoByIdAsync(int photoId);
    }
}
