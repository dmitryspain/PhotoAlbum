using PhotoAlbum.DAL.Entities.Base;
using System.Collections.Generic;

namespace PhotoAlbum.DAL.Entities
{
    public class Like : Entity<int>
    {
        public int PhotoId { get; set; }
        public virtual Photo Photo { get; set; }
        public string UserName { get; set; }
    }
}