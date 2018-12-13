using Microsoft.AspNet.Identity.EntityFramework;

namespace PhotoAlbum.DAL.Entities
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole(string name) : base(name)
        {
        }

        public ApplicationRole()
        {
        }
    }
}
