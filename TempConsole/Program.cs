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
            var ninjectKernel = new StandardKernel(new PhotoAlbum.BLL.Infrastructure.Bindings("ShopDbConnection"));
            var userService = ninjectKernel.Get<IUserService>();
            var roleService = ninjectKernel.Get<IRoleService>();
            var photoService = ninjectKernel.Get<IPhotoService>();
            var galleryService = ninjectKernel.Get<IGalleryService>();

            foreach(var user in userService.GetAllUsers())
            {

            }

            var query = photoService.GetAllPhotos();
            foreach(var q in query)
            {
                Console.WriteLine("id = " + q.Id  + " ");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

    }
}
