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

namespace PhotoAlbum.WebApi.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        private IUserService _userService;
        private IRoleService _roleService;

        public ValuesController(IUserService userService, IRoleService roleService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _roleService = roleService ?? throw new ArgumentNullException(nameof(roleService));
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            var asd = _userService.GetAll().Select(x=>x.UserName);
            return asd;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "5";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
