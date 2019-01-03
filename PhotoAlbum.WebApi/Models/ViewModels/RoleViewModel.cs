using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoAlbum.WebApi.Models.ViewModels
{
    public class RoleViewModel
    {
        public string Name { get; set; }
        public IEnumerable<UserViewModel> Users { get; set; }
    }
}