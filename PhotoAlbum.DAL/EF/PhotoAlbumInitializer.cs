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
                Id = 1,
                Description = "test photo",
                LastUpdate = DateTime.Now,
                UploadedDate = DateTime.Now
            };

            var photo2 = new Photo()
            {
                Id = 2,
                Description = "test photo 2",
                LastUpdate = DateTime.Now,
                UploadedDate = DateTime.Now
            };

            var photo3 = new Photo()
            {
                Id = 3,
                Description = "test photo 3",
                LastUpdate = DateTime.Now,
                UploadedDate = DateTime.Now
            };

            var photo4 = new Photo()
            {
                Id = 4,
                Description = "test photo 4",
                LastUpdate = DateTime.Now,
                UploadedDate = DateTime.Now
            };

            var photo5 = new Photo()
            {
                Id = 5,
                Description = "test photo 5",
                LastUpdate = DateTime.Now,
                UploadedDate = DateTime.Now
            };

            var gallery = new Gallery()
            {
                Id = 1,
                Photos = new List<Photo>()
                {
                    photo, photo2, photo3, photo4, photo5
                }
            };

            photo.GalleryId = gallery.Id;
            photo2.GalleryId = gallery.Id;
            photo3.GalleryId = gallery.Id;
            photo4.GalleryId = gallery.Id;
            photo5.GalleryId = gallery.Id;
            

            var role = new Role() { Id = 1 };
            var role2 = new Role() { Id = 2 };
            var role3 = new Role() { Id = 3 };
            var role4 = new Role() { Id = 4 };
            var role5 = new Role() { Id = 15 };

            var user = new User()
            {
                Id = 1,
                Name = "Dmitry",
                DateOfBirdth = new DateTime(1998, 11, 8),
                Description = "Im programmer",
                Email = "dmitrysp41n@gmail.com",
                Password = "password123",
                Roles = new List<Role>() { role, role2 },
                GalleryId = gallery.Id
            };
            gallery.UserId = user.Id;

            var user2 = new User()
            {
                Id = 2,
                Name = "Alex",
                DateOfBirdth = new DateTime(1991, 2, 8),
                Description = "Im Alex",
                Email = "Alex@gmail.com",
                Password = "AlexPassword",
                Roles = new List<Role>() { role, role3 },
                //GalleryId = gallery.Id
            };

            var user3 = new User()
            {
                Id = 3,
                Name = "Max",
                DateOfBirdth = new DateTime(1998, 10, 1),
                Description = "Im Max",
                Email = "Max@gmail.com",
                Password = "MaxPass",
                Roles = new List<Role>() { role4, role2 },
                //GalleryId = gallery.Id
            };

            var user4 = new User()
            {
                Id = 4,
                Name = "Moisiyaha",
                DateOfBirdth = new DateTime(1998, 11, 14),
                Description = "Im HS",
                Email = "HS@gmail.com",
                Password = "passwordHS",
                Roles = new List<Role>() { role, role5 },
                //GalleryId = gallery.Id
            };

            var user5 = new User()
            {
                Id = 4,
                Name = "Nikita",
                DateOfBirdth = new DateTime(1998, 4, 6),
                Description = "Im programmer",
                Email = "Nikita@gmail.com",
                Password = "NikitaPass",
                Roles = new List<Role>() { role3, role4 },
                //GalleryId = gallery.Id
            };

            context.Photos.AddRange(new [] { photo, photo2, photo3, photo4, photo5 });
            context.Users.AddRange(new [] { user, user2, user3, user4, user5 });
            context.Roles.AddRange(new [] { role, role2, role3, role4, role5 });
            context.Galleries.Add(gallery);

            context.SaveChanges();
            base.Seed(context);
        }
    }
}