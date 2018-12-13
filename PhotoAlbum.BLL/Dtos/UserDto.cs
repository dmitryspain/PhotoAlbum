using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.BLL.Dtos.Base;

namespace PhotoAlbum.BLL.Dtos
{
    public class UserDto : EntityDto<string>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string ClientProfileId { get; set; }
        public virtual ClientProfileDto ClientProfile { get; set; }
        public IEnumerable<string> RolesId { get; set; }
    }
}
