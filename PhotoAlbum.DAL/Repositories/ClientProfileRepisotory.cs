using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.DAL.EF;
using PhotoAlbum.DAL.Entities;
using PhotoAlbum.DAL.Interfaces.IRepository;
using PhotoAlbum.DAL.Repositories.Base;

namespace PhotoAlbum.DAL.Repositories
{
    public class ClientProfileRepository : BaseRepository<ClientProfile>, IClientProfilesRepository
    {
        public ClientProfileRepository(PhotoAlbumContext context)
            : base(context)
        {
        }
    }
}
