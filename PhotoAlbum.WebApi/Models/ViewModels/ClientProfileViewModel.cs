using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoAlbum.WebApi.Models.ViewModels
{
    public class ClientProfileViewModel
    {
        public string Description { get; set; }
        public virtual string Avatar { get; set; }
        public virtual ICollection<PhotoViewModel> Photos { get; set; } = new List<PhotoViewModel>();
    }
}