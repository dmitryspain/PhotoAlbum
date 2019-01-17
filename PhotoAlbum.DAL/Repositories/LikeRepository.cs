using PhotoAlbum.DAL.EF;
using PhotoAlbum.DAL.Entities;
using PhotoAlbum.DAL.Interfaces.IRepository;
using PhotoAlbum.DAL.Repositories.Base;

namespace PhotoAlbum.DAL.Repositories
{
    public class LikeRepository : BaseRepository<Like>, ILikeRepository
    {
        public LikeRepository(PhotoAlbumContext context)
            : base(context)
        {
        }
    }
}
