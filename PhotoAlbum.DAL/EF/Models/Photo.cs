using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.DAL.EF.Models.Base;

namespace PhotoAlbum.DAL.EF.Models
{
    public class Photo : Entity<int>
    {
        public string Description { get; set; }
        public DateTime LastUpdate { get; set; }
        public DateTime UploadedDate { get; set; }
        public virtual Gallery Gallery { get; set; }
    }
}
