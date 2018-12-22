using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.BLL.Dtos.Base;

namespace PhotoAlbum.BLL.Dtos
{
    public class GalleryDto : EntityDto<int>
    {
        public int? ClientProfileId { get; set; }
        public virtual ClientProfileDto ClientProfile { get; set; }
        public virtual ICollection<PhotoDto> Photos { get; set; }
    }
}
