using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PhotoAlbum.DAL.Entities.Base;

namespace PhotoAlbum.DAL.Entities
{
    public class ClientProfile : Entity<int>
    {
        [Required]
        public string Description { get; set; }
        public virtual byte[] Avatar { get; set; }
        public virtual ICollection<Photo> Photos { get; set; } = new List<Photo>();
    }
}
