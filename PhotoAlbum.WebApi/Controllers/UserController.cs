using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using PhotoAlbum.BLL.Dtos;
using PhotoAlbum.BLL.Interfaces;
using PhotoAlbum.BLL.Services;
using PhotoAlbum.Constans;
using PhotoAlbum.WebApi.Models.ViewModels;

namespace PhotoAlbum.WebApi.Controllers
{
    [RoutePrefix("api/Users")]
    public class UserController : ApiController
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IRoleService roleService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _roleService = roleService ?? throw new ArgumentNullException(nameof(roleService));

            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<int, RoleViewModel>()
                .ForMember(role => role.Name, opt => 
                opt.MapFrom(id => _roleService.FindById(id).Name));

                cfg.CreateMap<UserDto, UserViewModel>().
                ForMember(x=>x.Roles, opt=>opt.MapFrom(x=>x.RolesId));

                cfg.CreateMap<RoleDto, RoleViewModel>();
            }));
        }

        [HttpGet]
        [Authorize(RoleName.Admin, RoleName.User)]
        [Route("")]
        public async Task<IHttpActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllAsync();
            var usersViewModel = _mapper.Map<IEnumerable<UserViewModel>>(users);

            return Ok(usersViewModel);
        }

        [HttpDelete]
        [Authorize(Roles = RoleName.Admin)]
        [Route("{userName}/{roleName}")]
        public async Task<IHttpActionResult> DeleteFromRole(string userName, string roleName)
        {
            var user = await _userService.FindByNameAsync(userName);
            // if yes
            await _userService.RemoveFromRoleAsync(user.Id, roleName);

            return Ok();
        }

        [HttpPut]
        [Authorize(Roles = RoleName.Admin)]
        [Route("{userName}/{roleName}")]
        public async Task<IHttpActionResult> AddToRole(string userName, string roleName)
        {
            var user = await _userService.FindByNameAsync(userName);
            // if not
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
