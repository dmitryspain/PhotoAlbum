using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoAlbum.WebApi.Models.ViewModels
{
    public class UserViewModel
    {
        public IEnumerable<RoleViewModel> Roles { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}