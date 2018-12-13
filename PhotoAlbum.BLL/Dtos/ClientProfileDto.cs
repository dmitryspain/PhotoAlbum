using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.BLL.Dtos.Base;

namespace PhotoAlbum.BLL.Dtos
{
    public class ClientProfileDto : EntityDto<string>
    {
        public string Description { get; set; }
        public DateTime? DateOfBirdth { get; set; }

        public string GalleryId { get; set; }
        public virtual GalleryDto Gallery { get; set; }

        public string ApplicationUserId { get; set; }
        public virtual UserDto ApplicationUser { get; set; }
    }
}
