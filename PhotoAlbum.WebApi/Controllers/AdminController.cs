using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PhotoAlbum.BLL.Interfaces;

namespace PhotoAlbum.WebApi.Controllers
{
    public class AdminController : ApiController
    {
        private IUserService _userService;
        private IRoleService _roleService;

        public AdminController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }


    }
}
