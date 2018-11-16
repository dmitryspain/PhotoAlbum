using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.BLL.Dtos;

namespace PhotoAlbum.BLL.Interfaces
{
    interface IGalleryService : IDisposable
    {
        Task<GalleryDto> GetGalleryAsync();
        //Task<GalleryDto> GetSingleAsync(Expression<Func<GalleryDto, bool>> expression);
    }
}
