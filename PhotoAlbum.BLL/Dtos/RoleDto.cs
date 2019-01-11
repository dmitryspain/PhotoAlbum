using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.BLL.Dtos.Base;

namespace PhotoAlbum.BLL.Dtos
{
    public class RoleDto : EntityDto<int>
    {
        public string Name { get; set; }
        //public IEnumerable<UserDto> Users { get; set; }
    }
}
