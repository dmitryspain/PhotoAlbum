using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.DAL.EF;

namespace TempConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            PhotoAlbumContext context = new PhotoAlbumContext("PhotoAlbumDb");

            foreach (var i in context.Galleries)
            {
                Console.WriteLine("userId = " + i.Id);
                foreach(var asd in i.Photos)
                {
                    Console.WriteLine("photo = " + asd.Id + " " + asd.Description);
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
