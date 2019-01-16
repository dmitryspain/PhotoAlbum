using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using PhotoAlbum.DAL.Entities;
using PhotoAlbum.DAL.Entities.Identity;

namespace PhotoAlbum.DAL.EF
{
    public class PhotoAlbumContext : IdentityDbContext<ApplicationUser, ApplicationRole,
    int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public PhotoAlbumContext(string connectionString) 
            : base(connectionString)
        {
            Database.SetInitializer(new PhotoAlbumInitializer());
        }

        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Like> Likes { get; set; }
        public virtual DbSet<ClientProfile> ClientProfiles { get; set; }
    }
}
