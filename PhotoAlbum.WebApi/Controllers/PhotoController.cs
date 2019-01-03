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
using System.Security.Claims;
using AutoMapper;
using PhotoAlbum.WebApi.Models.ViewModels;

namespace PhotoAlbum.WebApi.Controllers
{
    public class PhotoController : ApiController
    {
        private IPhotoService _photoService;
        private IUserService _userService;
        private IMapper _mapper;

        public PhotoController(IPhotoService photoService, IUserService userService)
        {
            _photoService = photoService ?? throw new ArgumentNullException(nameof(photoService));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));

            //_mapper = new Mapper(new MapperConfiguration(cfg => {
            //    cfg.CreateMap<PhotoDto, PhotoViewModel>();
            //}));
        }

        //[HttpPost]
        //[Authorize(Roles = RoleName.User)]
        //[Route("api/UploadPhoto")]
        //public async Task<HttpResponseMessage> UploadPhoto()
        //{
        //    var httpRequest = HttpContext.Current.Request;
        //    var postedFile = httpRequest.Files["Image"];
        //    var imageName = new string(Path.GetFileNameWithoutExtension(postedFile.FileName)
        //        .Take(10)
        //        .ToArray())
        //        .Replace(' ', '-');
        //    imageName += DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);

        //    byte[] imageData;
        //    using (BinaryReader binaryReader = new BinaryReader(postedFile.InputStream))
        //    {
        //        imageData = binaryReader.ReadBytes(postedFile.ContentLength);
        //    }

        //    var userName = httpRequest["UserName"];
        //    var user = await _userService.FindByNameAsync(userName);

        //    PhotoDto photo = new PhotoDto()
        //    {
        //        ImageName = imageName,
        //        Description = httpRequest["ImageDescription"],
        //        UploadedDate = DateTime.Now,
        //        Data = Convert.ToBase64String(imageData),
        //        ContentType = postedFile.ContentType,
        //        ClientProfileDtoId = user.ClientProfileId,
        //    };

        //   _photoService.UploadPhoto(photo);
        //    return Request.CreateResponse(HttpStatusCode.Created);
        //}

        //[HttpGet]
        //[Authorize(Roles = RoleName.User)]
        //[Route("api/GetAllPhotos/{userName}")]
        //public async Task<IHttpActionResult> GetAllPhotos(string userName)
        //{
        //    var user = await _userService.FindByNameAsync(userName);
        //    var photos = await _photoService.GetUserPhotosAsync(user.Id);
        //    //var photoViewModels = _mapper.Map<IEnumerable<PhotoViewModel>>(photos);
        //    return Ok(photos);
        //}



        //[HttpGet]
        //[Authorize(Roles = RoleName.User)]
        //[Route("api/GetAvatar/{userName}")]
        //public async Task<PhotoDto> GetAvatar(string userName)
        //{
        //    var photo = await _photoService.GetSingleAsync(x => x.Id > 3);
        //    return photo;
        //}

        //[HttpPost]
        //[Authorize(Roles = RoleName.User)]
        //[Route("api/SetAvatar/{userName}")]
        //public async Task<PhotoDto> SetAvatar(string userName)
        //{
        //    var httpRequest = HttpContext.Current.Request;
        //    var postedFile = httpRequest.Files["Image"];
        //    var imageName = new String(Path.GetFileNameWithoutExtension(postedFile.FileName)
        //        .Take(10)
        //        .ToArray())
        //        .Replace(' ', '-');
        //    imageName += DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);

        //    byte[] imageData;
        //    using (BinaryReader binaryReader = new BinaryReader(postedFile.InputStream))
        //    {
        //        imageData = binaryReader.ReadBytes(postedFile.ContentLength);
        //    }

        //    var user = await _userService.FindByNameAsync(userName);

        //    PhotoDto photo = new PhotoDto()
        //    {
        //        ImageName = imageName,
        //        Data = Convert.ToBase64String(imageData),
        //        ClientProfileDtoId = user.ClientProfileId,
        //    };

        //    _photoService.UploadPhoto(photo);
        //    return null;//Request.CreateResponse(HttpStatusCode.Created);
        //}

    }
}
