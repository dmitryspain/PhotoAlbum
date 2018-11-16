using System;
using System.Collections.Generic;
using System.Data.Entity;
using PhotoAlbum.DAL.EF.Models;

namespace PhotoAlbum.DAL.EF
{
    internal class PhotoAlbumInitializer : DropCreateDatabaseAlways<PhotoAlbumContext>
    {
        protected override void Seed(PhotoAlbumContext context)
        {
            var photo = new Photo()
            {
                Description = "test photo",
                LastUpdate = DateTime.Now,
                UploadedDate = DateTime.Now
            };

            var gallery = new Gallery()
            {
                Photos = new List<Photo>()
                {
                    photo, new Photo()
                    {
                        Description = "test photo 2",
                        LastUpdate = DateTime.Now,
                        UploadedDate = DateTime.Now
                    }
                }
            };

            photo.Gallery = gallery;

            var role = new Role();

            var user = new User()
            {
                Name = "Dmitry",
                DateOfBirdth = new DateTime(1998, 11, 8),
                Description = "Im programmer",
                Email = "dmitrysp41n@gmail.com",
                Password = "password123",
                Roles = new List<Role>() { role },
                Gallery = gallery
            };

            context.Users.Add(user);
            context.Photos.Add(photo);
            context.Galleries.Add(gallery);
            context.Roles.Add(role);

            context.SaveChanges();
            base.Seed(context);
        }
    }
}