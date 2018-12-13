using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using PhotoAlbum.DAL.EF.Models;
using PhotoAlbum.DAL.Entities;

namespace PhotoAlbum.DAL.EF
{
    public class PhotoAlbumContext : IdentityDbContext<ApplicationUser>
    {
        public PhotoAlbumContext(string connectionString) 
            : base(connectionString)
        {
            Database.SetInitializer(new PhotoAlbumInitializer());
            Debug.WriteLine(Database.Connection.ConnectionString);
        }

        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Gallery> Galleries { get; set; }
        public virtual DbSet<ClientProfile> ClientProfiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //todo Fix AppUsers with clientAccounts
            modelBuilder.Entity<ApplicationUser>()
                .HasKey(c => c.Id)
                .Property(c => c.Id);

            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<ApplicationUser>()
                .HasRequired(c => c.ClientProfile).WithRequiredPrincipal(c => c.ApplicationUser);

            base.OnModelCreating(modelBuilder);
        }
    }

}
