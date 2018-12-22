using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using PhotoAlbum.DAL.EF;

namespace PhotoAlbum.DAL.Entities.Identity
{

    public class CustomUserRole : IdentityUserRole<int> { }
    public class CustomUserClaim : IdentityUserClaim<int> { }
    public class CustomUserLogin : IdentityUserLogin<int> { }

    //public class CustomRole : IdentityRole<int, CustomUserRole>
    //{
    //    public CustomRole() { }
    //    public CustomRole(string name) { Name = name; }
    //}

    public class CustomUserStore : UserStore<ApplicationUser, ApplicationRole, int,
        CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public CustomUserStore(PhotoAlbumContext context)
            : base(context)
        {
        }
    }

    public class CustomRoleStore : RoleStore<ApplicationRole, int, CustomUserRole>
    {
        public CustomRoleStore(PhotoAlbumContext context)
            : base(context)
        {
        }
    }
    
}
