using PhotoAlbum.BLL.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.BLL.Dtos
{
    public class LikeDto : EntityDto<int>
    {
        public int PhotoDtoId { get; set; }
        public string UserName { get; set; }
    }
}
