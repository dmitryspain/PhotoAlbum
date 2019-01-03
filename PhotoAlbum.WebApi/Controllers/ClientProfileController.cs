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
using PhotoAlbum.WebApi.Models.ViewModels;

namespace PhotoAlbum.WebApi.Controllers
{
    public class ClientProfileController : ApiController
    {
        private IClientProfileService _clientProfileService;
        private IUserService _userService;
        private IPhotoService _photoService;
        private IMapper _mapper;

        public ClientProfileController(IClientProfileService clientProfileService, IUserService userService, IPhotoService photoService)
        {
            _clientProfileService = clientProfileService ?? throw new ArgumentNullException(nameof(clientProfileService));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _photoService = photoService ?? throw new ArgumentNullException(nameof(photoService));

            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClientProfileDto, ClientProfileViewModel>();
            }));
        }

        [HttpGet]
        [Authorize(Roles = RoleName.User)]
        [Route("api/GetProfileData/{userName}")]
        public async Task<IHttpActionResult> GetProfileData(string userName)
        {
            var user = await _userService.FindByNameAsync(userName);
            var profileDto = await _clientProfileService.GetProfileData(user);
            var profile = _mapper.Map<ClientProfileViewModel>(profileDto);

            return Ok(profile);
        }

        [HttpPost]
        [Authorize(Roles = RoleName.User)]
        [Route("api/SetAvatar/{userName}")]
        public async Task<HttpResponseMessage> SetAvatar(string userName)
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

            var user = await _userService.FindByNameAsync(userName);

            PhotoDto photo = new PhotoDto()
            {
                ImageName = imageName,
                Data = Convert.ToBase64String(imageData),
                ClientProfileDtoId = user.ClientProfileId,
            };

            var profile = await _clientProfileService.FindByIdAsync(user.ClientProfileId);

            await _clientProfileService.SetAvatar(profile.Id, photo);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPost]
        [Authorize(Roles = RoleName.User)]
        [Route("api/UploadPhoto")]
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

            var test = User.Identity.Name;
            var test2 = RequestContext.Principal.Identity.Name;

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
    }
}
