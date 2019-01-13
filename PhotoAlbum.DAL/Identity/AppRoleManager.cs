using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using PhotoAlbum.DAL.EF;
using PhotoAlbum.DAL.Entities;
using PhotoAlbum.DAL.Entities.Identity;

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
