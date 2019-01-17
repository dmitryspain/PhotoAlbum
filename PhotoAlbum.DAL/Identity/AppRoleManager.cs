using Microsoft.AspNet.Identity;
using PhotoAlbum.DAL.Entities;

namespace PhotoAlbum.DAL.Identity
{
    public class AppRoleManager : RoleManager<ApplicationRole, int>
    {
        public AppRoleManager(IRoleStore<ApplicationRole, int> store)
                    : base(store)
        {
        }
    }
}
