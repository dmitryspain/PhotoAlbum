using AutoMapper;
using PhotoAlbum.BLL.Dtos;
using PhotoAlbum.BLL.Interfaces;
using PhotoAlbum.Constans;
using PhotoAlbum.WebApi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PhotoAlbum.WebApi.Controllers
{
    [RoutePrefix("api/Admins")]
    public class AdminController : ApiController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AdminController(IUserService userService)
        {
            _userService = userService;
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDto, UserViewModel>().
                ForMember(x => x.Roles, opt => opt.MapFrom(x => x.RolesId));
            }));
        }

        [HttpDelete]
        [Authorize(Roles = RoleName.Admin)]
        [Route("{userName}/{roleName}")]
        public async Task<IHttpActionResult> DeleteFromRole(string userName, string roleName)
        {
            var user = await _userService.FindByNameAsync(userName);
            await _userService.RemoveFromRoleAsync(user.Id, roleName);

            return Ok();
        }

        [HttpPut]
        [Authorize(Roles = RoleName.Admin)]
        [Route("{userName}/{roleName}")]
        public async Task<IHttpActionResult> AddToRole(string userName, string roleName)
        {
            var user = await _userService.FindByNameAsync(userName);
            await _userService.AddToRoleAsync(user.Id, roleName);

            return Ok();
        }

        [HttpDelete]
        [Authorize(Roles = RoleName.Admin)]
        [Route("{userName}")]
        public async Task<IHttpActionResult> DeleteUser(string userName)
        {
            var user = await _userService.FindByNameAsync(userName);
            await _userService.DeleteAsync(user.Id);

            return Ok();
        }
    }
}
