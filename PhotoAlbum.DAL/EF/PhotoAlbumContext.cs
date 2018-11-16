using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.DAL.EF.Models;

namespace PhotoAlbum.DAL.EF
{
    public class PhotoAlbumContext : DbContext
    {
        public PhotoAlbumContext(string connectionString) 
            : base(connectionString)
        {
            Database.SetInitializer(new PhotoAlbumInitializer());
        }

        public DbSet<Photo> Photos { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
