using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.DAL.EF.Models.Base;

namespace PhotoAlbum.DAL.EF.Models
{
    public class Gallery : Entity<int>
    {
        public virtual User User { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
    }
}
