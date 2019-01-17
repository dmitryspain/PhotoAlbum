using PhotoAlbum.BLL.Dtos.Base;

namespace PhotoAlbum.BLL.Dtos
{
    public class LikeDto : EntityDto<int>
    {
        public int PhotoDtoId { get; set; }
        public string UserName { get; set; }
    }
}
