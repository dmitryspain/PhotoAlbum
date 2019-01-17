using PhotoAlbum.DAL.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace PhotoAlbum.DAL.Entities
{
    public class Like : Entity<int>
    {
        public int PhotoId { get; set; }
        public virtual Photo Photo { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}