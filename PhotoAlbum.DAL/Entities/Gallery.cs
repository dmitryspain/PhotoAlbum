using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using PhotoAlbum.DAL.Entities;
using PhotoAlbum.DAL.Entities.Base;

namespace PhotoAlbum.DAL.Entities
{
    public class Gallery : Entity<int>
    {
        [Key, ForeignKey("ClientProfile")]
        public string ClientProfileId { get; set; }
        public virtual ClientProfile ClientProfile { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
    }
}
