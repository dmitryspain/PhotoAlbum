using System;
using System.Collections.Generic;
using System.Data.Entity;
using PhotoAlbum.DAL.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PhotoAlbum.DAL.Entities;
using Microsoft.AspNet.Identity;
using System.Diagnostics;
using PhotoAlbum.DAL.Entities.Identity;
using PhotoAlbum.Constans;

namespace PhotoAlbum.DAL.EF
{
    internal class PhotoAlbumInitializer : DropCreateDatabaseAlways<PhotoAlbumContext>
    {
        private void Method(PhotoAlbumContext context)
        {
            AppUserManager userManager = new AppUserManager(new UserStore<ApplicationUser, ApplicationRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>(context));
            AppRoleManager roleManager = new AppRoleManager(new CustomRoleStore(context));

            if (!roleManager.RoleExists("Admins"))
                roleManager.Create(new ApplicationRole() { Name = "Administrators" });

            if (!roleManager.RoleExists("Users"))
                roleManager.Create(new ApplicationRole() { Name = "Users" });

            var photo = new Photo()
            {
                Description = "testPhoto",
            };
            context.Photos.Add(photo);
            var clientProfile = new ClientProfile()
            {
                DateOfBirdth = DateTime.Now,
                Description = "testClient",
                Photos = new List<Photo>(),
            };
            clientProfile.Photos.Add(photo);
            context.ClientProfiles.Add(clientProfile);

            var user = userManager.FindByName("qwerty");
            if (user == null)
            {
                userManager.Create(new ApplicationUser()
                {
                    UserName = "qwerty",
                    Email = "qwerty@test.com",
                    ClientProfileId = clientProfile.Id,
                }, "qwerty123");

                //userManager.Create(new ApplicationUser()
                //{
                //    UserName = "PETYA",
                //    Email = "PETYA@gmail.com",
                //}, "123456");

                user = userManager.FindByName("qwerty");
            };

            if (!userManager.IsInRole(user.Id, RoleName.Admin))
                userManager.AddToRole(user.Id, RoleName.Admin);

            if (!userManager.IsInRole(user.Id, RoleName.User))
                userManager.AddToRole(user.Id, RoleName.User);

            context.SaveChanges();
        }

        protected override void Seed(PhotoAlbumContext context)
        {
            Method(context);






            //var photo = new Photo()
            //{
            //    Description = "test photo",
            //    LastUpdate = DateTime.Now,
            //    UploadedDate = DateTime.Now
            //};

            //var photo2 = new Photo()
            //{
            //    Description = "test photo 2",
            //    LastUpdate = DateTime.Now,
            //    UploadedDate = DateTime.Now
            //};

            //var photo3 = new Photo()
            //{
            //    Description = "test photo 3",
            //    LastUpdate = DateTime.Now,
            //    UploadedDate = DateTime.Now
            //};

            //var photo4 = new Photo()
            //{
            //    Description = "test photo 4",
            //    LastUpdate = DateTime.Now,
            //    UploadedDate = DateTime.Now
            //};

            //var photo5 = new Photo()
            //{
            //    Description = "test photo 5",
            //    LastUpdate = DateTime.Now,
            //    UploadedDate = DateTime.Now
            //};

            //var gallery = new Gallery()
            //{
            //    Photos = new List<Photo>()
            //    {
            //        photo, photo2, photo3, photo4, photo5
            //    }
            //};

            ////photo.GalleryId = gallery.Id;
            ////photo2.GalleryId = gallery.Id;
            ////photo3.GalleryId = gallery.Id;
            ////photo4.GalleryId = gallery.Id;
            ////photo5.GalleryId = gallery.Id;
            

            //var role = new Role() { };
            //var role2 = new Role() {};
            //var role3 = new Role() {  };
            //var role4 = new Role() { };
            //var role5 = new Role() {  };

            //var user = new User()
            //{
            //    UserName = "Dmitry",
            //    DateOfBirdth = new DateTime(1998, 11, 8),
            //    Description = "Im programmer",
            //    Email = "dmitrysp41n@gmail.com",
            //    //Password = "password123",
            //    //GalleryId = gallery.Id
            //};

            //var user2 = new User()
            //{
            //    UserName = "Alex",
            //    DateOfBirdth = new DateTime(1991, 2, 8),
            //    Description = "Im Alex",
            //    Email = "Alex@gmail.com",
            //    //Password = "AlexPassword",
            //    //GalleryId = gallery.Id
            //};

            //var user3 = new User()
            //{
            //    UserName = "Max",
            //    DateOfBirdth = new DateTime(1998, 10, 1),
            //    Description = "Im Max",
            //    Email = "Max@gmail.com",
            //    //Password = "MaxPass",
            //    //GalleryId = gallery.Id
            //};

            //var user4 = new User()
            //{
            //    UserName = "Moisiyaha",
            //    DateOfBirdth = new DateTime(1998, 11, 14),
            //    Description = "Im HS",
            //    Email = "HS@gmail.com",
            //    //Password = "passwordHS",
            //    //GalleryId = gallery.Id
            //};

            //var user5 = new User()
            //{
            //    UserName = "Nikita",
            //    DateOfBirdth = new DateTime(1998, 4, 6),
            //    Description = "Im programmer",
            //    Email = "Nikita@gmail.com",
            //    //Password = "NikitaPass",
            //    //GalleryId = gallery.Id
            //};

            //context.Photos.AddRange(new [] { photo, photo2, photo3, photo4, photo5 });
            ////context.Users.AddRange(new [] { user, user2, user3, user4, user5 });
            ////context.Roles.AddRange(new [] { role, role2, role3, role4, role5 });
            //context.Galleries.Add(gallery);

            //context.SaveChanges();
            //base.Seed(context);
        }
    }
}