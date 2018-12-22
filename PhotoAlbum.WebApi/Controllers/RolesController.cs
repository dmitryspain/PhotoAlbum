using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using PhotoAlbum.BLL.Interfaces;

namespace PhotoAlbum.WebApi.Controllers
{
    public class RolesController : ApiController
    {
        private IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        [Route("api/GetAllRoles")]
        public async Task<HttpResponseMessage> GetAllRoles()
        {
            var roles = await _roleService.GetAllAsync();
            return Request.CreateResponse(HttpStatusCode.OK, roles);
        }


    }
}
