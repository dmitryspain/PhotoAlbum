using PhotoAlbum.BLL.Dtos.Base;

namespace PhotoAlbum.BLL.Dtos
{
    public class RoleDto : EntityDto<int>
    {
        public string Name { get; set; }
    }
}
