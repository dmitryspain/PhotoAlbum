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
using PhotoAlbum.WebApi.Models.ViewModels;

namespace PhotoAlbum.WebApi.Controllers
{
    [RoutePrefix("api/Roles")]
    public class RolesController : ApiController
    {
        private IRoleService _roleService;
        private IMapper _mapper;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RoleDto, RoleViewModel>();
            }));
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetAllRoles()
        {
            var roles = await _roleService.GetAllAsync();
            var rolesViewModel = _mapper.Map<IEnumerable<RoleViewModel>>(roles);
            return Request.CreateResponse(HttpStatusCode.OK, rolesViewModel);
        }

    }
}
