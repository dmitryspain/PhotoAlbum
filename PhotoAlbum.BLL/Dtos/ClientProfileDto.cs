using System.Collections.Generic;
using PhotoAlbum.BLL.Dtos.Base;

namespace PhotoAlbum.BLL.Dtos
{
    public class ClientProfileDto : EntityDto<int>
    {
        public string Description { get; set; }
        public virtual string Avatar { get; set; }
        public virtual ICollection<PhotoDto> Photos { get; set; } = new List<PhotoDto>();
    }
}
