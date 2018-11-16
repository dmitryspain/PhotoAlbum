using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PhotoAlbum.DAL.EF;
using System.Web.Http.Results;
using PhotoAlbum.DAL.EF.Models;

namespace PhotoAlbum.Controllers
{
    public class HomeController : ApiController
    {

        public JsonResult<User> Get()
        {
            PhotoAlbumContext context = new PhotoAlbumContext("PhotoAlbumDb");

            foreach(var i in context.Users)
            {
                Console.WriteLine("userId = " + i.Id + " name = " + i.Name);
            }

            return Json(context.Users.First());
        }

    }
}
