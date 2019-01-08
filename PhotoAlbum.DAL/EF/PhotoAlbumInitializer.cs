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
    internal class PhotoAlbumInitializer : DropCreateDatabaseIfModelChanges<PhotoAlbumContext>
    {
        protected override void Seed(PhotoAlbumContext context)
        {
            AppUserManager userManager = new AppUserManager(new UserStore<ApplicationUser, ApplicationRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>(context));
            AppRoleManager roleManager = new AppRoleManager(new CustomRoleStore(context));

            if (!roleManager.RoleExists("Admins"))
                roleManager.Create(new ApplicationRole() { Name = "Administrators" });

            if (!roleManager.RoleExists("Users"))
                roleManager.Create(new ApplicationRole() { Name = "Users" });



            var clientProfile = new ClientProfile()
            {
                DateOfBirdth = DateTime.Now,
                Description = "qwertyClient",
                Photos = new List<Photo>(),
            };
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

                user = userManager.FindByName("qwerty");
            };

            if (!userManager.IsInRole(user.Id, RoleName.Admin))
                userManager.AddToRole(user.Id, RoleName.Admin);

            if (!userManager.IsInRole(user.Id, RoleName.User))
                userManager.AddToRole(user.Id, RoleName.User);

            context.SaveChanges();
        }
    }
}