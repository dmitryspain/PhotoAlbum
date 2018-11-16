using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.DAL.EF.Interfaces.IRepository;
using PhotoAlbum.DAL.EF.Models;
using PhotoAlbum.DAL.EF.Repositories.Base;

namespace PhotoAlbum.DAL.EF.Repositories
{
    public class PhotoRepository : BaseRepository<Photo>, IPhotoRepository
    {
        public PhotoRepository(PhotoAlbumContext context)
            : base(context)
        {
        }
    }
}
