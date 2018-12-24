using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web.Http;
using PhotoAlbum.BLL.Dtos;
using PhotoAlbum.BLL.Interfaces;
using System.Net.Http.Headers;
using PhotoAlbum.Constans;

namespace PhotoAlbum.WebApi.Controllers
{
    public class PhotoController : ApiController
    {
        private IPhotoService _photoService;
        private IUserService _userService;

        public PhotoController(IPhotoService photoService, IUserService userService)
        {
            _photoService = photoService;
            _userService = userService;
        }

        [HttpPost]
        [Authorize(Roles = RoleName.User)]
        [Route("api/UploadPhoto")]
        public async Task<HttpResponseMessage> UploadPhoto()
        {
            var httpRequest = HttpContext.Current.Request;
            var postedFile = httpRequest.Files["Image"];
            var imageName = new String(Path.GetFileNameWithoutExtension(postedFile.FileName)
                .Take(10)
                .ToArray())
                .Replace(' ', '-');
            imageName += DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);

            byte[] imageData;
            using (BinaryReader binaryReader = new BinaryReader(postedFile.InputStream))
            {
                imageData = binaryReader.ReadBytes(postedFile.ContentLength);
            }

            var userName = httpRequest["UserName"];
            var user = await _userService.FindByNameAsync(userName);

     
            PhotoDto photo = new PhotoDto()
            {
                ImageName = imageName,
                Description = httpRequest["ImageDescription"],
                UploadedDate = DateTime.Now,
                Data = imageData,
                ContentType = postedFile.ContentType,
                ClientProfileDtoId = user.ClientProfileId,
                //ClientProfile = user.ClientProfile // remove this later
            };
            try
            {
               _photoService.UploadPhoto(photo);
            }
            catch(Exception ex)
            {

            }
            return Request.CreateResponse(HttpStatusCode.Created);
        }
    }
}
