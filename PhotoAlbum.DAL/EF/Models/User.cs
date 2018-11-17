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
    public class User : Entity<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public DateTime? DateOfBirdth { get; set; }
        [Key, ForeignKey("Gallery")]
        public int? GalleryId { get; set; }
        public virtual Gallery Gallery { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
