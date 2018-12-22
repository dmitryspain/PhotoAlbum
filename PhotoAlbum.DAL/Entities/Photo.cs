using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.DAL.Entities.Base;

namespace PhotoAlbum.DAL.Entities
{
    public class Photo : Entity<int>
    {
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public DateTime? LastUpdate { get; set; }
        public DateTime? UploadedDate { get; set; }

        //[ForeignKey("ClientProfile")]
        public int? ClientProfileId { get; set; }

        //[Required]
        public ClientProfile ClientProfile { get; set; }
        //public string GalleryId { get; set; }
        //public virtual Gallery Gallery { get; set; }
    }
}
