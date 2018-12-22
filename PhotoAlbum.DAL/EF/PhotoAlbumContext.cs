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
            Debug.WriteLine(Database.Connection.ConnectionString);
        }

        public static PhotoAlbumContext Create()
        {
            return new PhotoAlbumContext("Server=(localdb)\\mssqllocaldb;Database=PhotoAlbum;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<ClientProfile> ClientProfiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ApplicationUser>()
            //    .HasKey(c => c.Id)
            //    .Property(x => x.ClientProfileId);

            //modelBuilder.Entity<ApplicationUser>()
            //    .HasKey(c=>c.Id)
            //    .HasRequired(c => c.ClientProfile);

            //modelBuilder.Entity<ClientProfile>()
            //    .HasKey(c=>c.Id)
            //    .HasRequired(c => c.ApplicationUser);

            //.WithRequiredPrincipal(c => c.ApplicationUser);
            //modelBuilder.Entity<ClientProfile>()
            //    .HasOptional(x => x.ApplicationUser);

            //modelBuilder.Entity<ClientProfile>()
            //    .HasKey(x => x.Id)
            //    .Property(x => x.Id)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //modelBuilder.Entity<ClientProfile>().HasRequired(x => x.ApplicationUser).WithRequiredPrincipal(x => x.ClientProfile);









            base.OnModelCreating(modelBuilder);
        }
    }

}
