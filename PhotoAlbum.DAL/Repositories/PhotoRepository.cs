using PhotoAlbum.DAL.EF;
using PhotoAlbum.DAL.EF.Models;
using PhotoAlbum.DAL.Interfaces.IRepository;
using PhotoAlbum.DAL.Repositories.Base;

namespace PhotoAlbum.DAL.Repositories
{
    public class PhotoRepository : BaseRepository<Photo>, IPhotoRepository
    {
        public PhotoRepository(PhotoAlbumContext context)
            : base(context)
        {
        }
    }
}
