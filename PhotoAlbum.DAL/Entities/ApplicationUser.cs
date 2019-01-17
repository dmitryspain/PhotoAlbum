using Microsoft.AspNet.Identity.EntityFramework;
using PhotoAlbum.DAL.Entities.Identity;

namespace PhotoAlbum.DAL.Entities
{
    public class ApplicationUser : IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public int ClientProfileId { get; set; }
        public virtual ClientProfile ClientProfile { get; set; }
    }
}
