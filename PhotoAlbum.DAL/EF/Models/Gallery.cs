using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.DAL.EF.Models.Base;

namespace PhotoAlbum.DAL.EF.Models
{
    public class Gallery : Entity<int>
    {
        [Key, ForeignKey("User")]
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
    }
}
