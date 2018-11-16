using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.BLL.Dtos.Base;

namespace PhotoAlbum.BLL.Dtos
{
    public class UserDto : EntityDto<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public DateTime DateOfBirdth { get; set; }
        public virtual GalleryDto Gallery { get; set; }
        public virtual ICollection<RoleDto> Roles { get; set; }
    }
}
