using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using PhotoAlbum.DAL.EF;
using PhotoAlbum.BLL.Interfaces;
using PhotoAlbum.BLL.Dtos;

namespace TempConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var ninjectKernel = new StandardKernel(new PhotoAlbum.BLL.Infrastructure.Bindings("PhotoAlbum"));
            var userService = ninjectKernel.Get<IUserService>();
            var roleService = ninjectKernel.Get<IRoleService>();
            var photoService = ninjectKernel.Get<IPhotoService>();
            var galleryService = ninjectKernel.Get<IGalleryService>();

            Method(userService, roleService);

            

            var query = userService.GetAll();
            //foreach (var q in query)
            //{
            //    Console.WriteLine("id = " + q.Id + " " + q.UserName /*q.Gallery.Id*/);
            //}

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        public static async Task Method(IUserService service, IRoleService roleService)
        {
            var users = await roleService.GetAllRolesAsync(x=>x.Name.Length>1);

            foreach(var user in users)
            {
                Console.WriteLine("userId = " + user.Id + " name = " + user.Name);
            }
            //foreach(var user in await service.GetAllAsync())
            //{
            //    Console.WriteLine("id = " + user.Id + " name = " + user.UserName);
            //}
            await Task.FromResult(0);
        }

    }
}
