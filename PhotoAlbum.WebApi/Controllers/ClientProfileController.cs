using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using AutoMapper;
using PhotoAlbum.BLL.Dtos;
using PhotoAlbum.BLL.Interfaces;
using PhotoAlbum.Constans;
using PhotoAlbum.WebApi.Filters;
using PhotoAlbum.WebApi.Models.ViewModels;

namespace PhotoAlbum.WebApi.Controllers
{
    //[GlobalExceptionFilter]
    [RoutePrefix("api/ClientProfiles")]
    public class ClientProfileController : ApiController
    {
        private readonly IClientProfileService _clientProfileService;
        private readonly IPhotoService _photoService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public ClientProfileController(
            IClientProfileService clientProfileService, 
            IUserService userService, 
            IPhotoService photoService)
        {
            _clientProfileService = clientProfileService;
            _userService = userService;
            _photoService = photoService;

            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClientProfileDto, ClientProfileViewModel>();
                cfg.CreateMap<PhotoDto, PhotoViewModel>();
                cfg.CreateMap<LikeDto, LikeViewModel>();
            }));
        }

        [HttpGet]
        [Authorize(RoleName.Admin, RoleName.User)]
        [Route("{userName}")]
        public async Task<IHttpActionResult> GetProfile(string userName)
        {
            var user = await _userService.FindByNameAsync(userName);
            var profileDto = await _clientProfileService.GetProfileAsync(user.Id);
            var profile = _mapper.Map<ClientProfileViewModel>(profileDto);

            return Ok(profile);
        }

        [HttpPost]
        [Authorize(RoleName.Admin, RoleName.User)]
        [Route("SetAvatar/{userName}")]
        public async Task<HttpResponseMessage> SetAvatar(string userName)
        {
            var httpRequest = HttpContext.Current.Request;
            var postedFile = httpRequest.Files["Image"];

            byte[] imageData;

            using (BinaryReader binaryReader = new BinaryReader(postedFile.InputStream))
                imageData = binaryReader.ReadBytes(postedFile.ContentLength);

            var user = await _userService.FindByNameAsync(userName);
            var profile = await _clientProfileService.FindByIdAsync(user.ClientProfileId);

            await _clientProfileService.SetAvatarAsync(profile.Id, imageData);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPost]
        [Authorize(RoleName.Admin, RoleName.User)]
        [Route("UploadPhoto")]
        public async Task<HttpResponseMessage> UploadPhoto()
        {
            var httpRequest = HttpContext.Current.Request;
            var postedFile = httpRequest.Files["Image"];
            var imageName = new string(Path.GetFileNameWithoutExtension(postedFile.FileName)
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
                Data = Convert.ToBase64String(imageData),
                ContentType = postedFile.ContentType,
                ClientProfileDtoId = user.ClientProfileId,
            };

            _photoService.UploadPhoto(photo);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpGet]
        [Authorize(RoleName.Admin, RoleName.User)]
        [Route("GetPhoto/{photoId}")]
        public async Task<IHttpActionResult> GetPhoto(int photoId)
        {
            var photoDto = await _photoService.GetPhotoByIdAsync(photoId);
            var photoViewModel = _mapper.Map<PhotoViewModel>(photoDto);
            return Ok(photoViewModel);
        }

        [HttpDelete]
        [Authorize(RoleName.Admin, RoleName.User)]
        [Route("RemovePhoto/{photoId}")]
        public IHttpActionResult RemovePhoto(int photoId)
        {
            _photoService.RemovePhoto(photoId);
            return Ok();
        }

        [HttpPut]
        [Authorize(RoleName.Admin, RoleName.User)]
        [Route("LikePhoto/{photoId}/{userName}")]
        public async Task<IHttpActionResult> LikePhoto(int photoId, string userName)
        {
            var photo = await _photoService.GetPhotoByIdAsync(photoId);
            var user = await _userService.FindByNameAsync(userName);
            await _photoService.LikeAsync(photoId, user.Id);

            return Ok();
        }

        [HttpPut]
        [Authorize(RoleName.Admin, RoleName.User)]
        [Route("ChangeDescription/{userName}")]
        public async Task<IHttpActionResult> ChangeDescription(string userName)
        {
            var httpRequest = HttpContext.Current.Request;
            var description = httpRequest["Description"];

            var user = await _userService.FindByNameAsync(userName);
            var clientProfile = await _clientProfileService.FindByIdAsync(user.Id);
            clientProfile.Description = description;
            await _clientProfileService.ChangeDescriptionAsync(clientProfile);

            return Ok();
        }
    }
}
