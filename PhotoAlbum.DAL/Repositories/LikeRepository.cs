using PhotoAlbum.DAL.EF;
using PhotoAlbum.DAL.Entities;
using PhotoAlbum.DAL.Interfaces.IRepository;
using PhotoAlbum.DAL.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
