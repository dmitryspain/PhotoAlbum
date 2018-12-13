using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PhotoAlbum.DAL.Entities;

namespace PhotoAlbum.DAL.Identity
{
    public class AppRoleManager : RoleManager<ApplicationRole>
    {
        public AppRoleManager(RoleStore<ApplicationRole> store)
                    : base(store)
        {
        }

    }
}
