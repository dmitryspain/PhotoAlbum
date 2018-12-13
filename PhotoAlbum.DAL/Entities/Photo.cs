using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.DAL.Entities.Base;

namespace PhotoAlbum.DAL.EF.Models
{
    public class Photo : Entity<string>
    {
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public DateTime? LastUpdate { get; set; }
        public DateTime? UploadedDate { get; set; }
        public string GalleryId { get; set; }
        public virtual Gallery Gallery { get; set; }
    }
}
