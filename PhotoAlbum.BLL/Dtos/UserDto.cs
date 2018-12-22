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
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //public string Role { get; set; }
        public int ClientProfileId { get; set; }
        public virtual ClientProfileDto ClientProfile { get; set; }
        //public IEnumerable<int> RolesId { get; set; }
    }
}
