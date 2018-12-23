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
        public string ImageName { get; set; }
        public string Description { get; set; }
        public DateTime? UploadedDate { get; set; }

        public int? ClientProfileDtoId { get; set; }
        public ClientProfileDto ClientProfile { get; set; }
    }
}
