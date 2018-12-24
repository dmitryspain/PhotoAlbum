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
        public int ClientProfileDtoId { get; set; }
        public string ImageName { get; set; }
        public string Description { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
        public DateTime? UploadedDate { get; set; }
    }
}
