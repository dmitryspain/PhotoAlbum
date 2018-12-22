using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.BLL.Dtos.Base;

namespace PhotoAlbum.BLL.Dtos
{
    public class PhotoDto : EntityDto<int>
    {
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public DateTime? LastUpdate { get; set; }
        public DateTime? UploadedDate { get; set; }
        public int? GalleryId { get; set; }
        public virtual GalleryDto Gallery { get; set; }
    }
}
