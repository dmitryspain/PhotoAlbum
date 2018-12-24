using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.BLL.Dtos.Base;

namespace PhotoAlbum.BLL.Dtos
{
    public class ClientProfileDto : EntityDto<int>
    {
        public string Description { get; set; }
        public DateTime? DateOfBirdth { get; set; }
        public virtual ICollection<PhotoDto> Photos { get; set; }

        public ClientProfileDto()
        {
            Photos = new List<PhotoDto>();
        }
    }
}
