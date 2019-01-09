using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using PhotoAlbum.BLL.Dtos;
using PhotoAlbum.BLL.Interfaces;
using PhotoAlbum.BLL.Services;
using PhotoAlbum.Constans;
using PhotoAlbum.WebApi.Models.ViewModels;

namespace PhotoAlbum.WebApi.Controllers
{

    public class UserController : ApiController
    {
        private const string AdminAndUser = "Administrators,Users";
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public UserController(IUserService userService, IRoleService roleService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _roleService = roleService ?? throw new ArgumentNullException(nameof(roleService));
        }

        [HttpGet]
        [Authorize(Roles = RoleName.User)]
        [Route("api/GetAllUsers")]
        public async Task<IHttpActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllAsync();
            var usersViewModel = new List<UserViewModel>();

            foreach (var user in users)
            {
                usersViewModel.Add(new UserViewModel()
                {
                    UserName = user.UserName,
                    Email = user.Email,
                });
            }
            return Ok(usersViewModel);
        }
    }
}
