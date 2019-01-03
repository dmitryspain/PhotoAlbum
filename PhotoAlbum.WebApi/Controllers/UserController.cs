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

namespace PhotoAlbum.WebApi.Controllers
{
    //[Authorize]
    public class UserViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserController : ApiController
    {
        private const string AdminAndUser = "Administrators,Users";
        private IUserService _userService;
        private IRoleService _roleService;

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
                    //Password = user.Password
                });
            }
            return Ok(usersViewModel);
        }
    }
}
