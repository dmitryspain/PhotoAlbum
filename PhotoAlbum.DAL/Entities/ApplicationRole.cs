using Microsoft.AspNet.Identity.EntityFramework;
using PhotoAlbum.DAL.Entities.Identity;

namespace PhotoAlbum.DAL.Entities
{
    public class ApplicationRole : IdentityRole<int, CustomUserRole>
    {
        public ApplicationRole(string name) 
        {
            Name = name;
        }

        public ApplicationRole()
        {
        }
    }
}
