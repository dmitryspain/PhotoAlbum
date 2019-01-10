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
        public string ImageName { get; set; }
        public string Description { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
        public DateTime? UploadedDate { get; set; }
        public virtual List<Like> Likes { get; set; } = new List<Like>();
        public int ClientProfileId { get; set; }
        public ClientProfile ClientProfile { get; set; }
    }
}
