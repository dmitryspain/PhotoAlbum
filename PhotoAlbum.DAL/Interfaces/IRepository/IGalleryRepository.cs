using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.DAL.EF.Models;

namespace PhotoAlbum.DAL.Interfaces.IRepository
{
    public interface IGalleryRepository : IRepository<Gallery>
    {
    }
}
