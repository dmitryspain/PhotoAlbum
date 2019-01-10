using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoAlbum.WebApi.Models.ViewModels
{
    public class LikeViewModel
    {
        public int PhotoId { get; set; }
        public string UserName { get; set; }
    }
}