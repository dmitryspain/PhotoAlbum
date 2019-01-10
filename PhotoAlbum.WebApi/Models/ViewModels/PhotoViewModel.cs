using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoAlbum.WebApi.Models.ViewModels
{
    public class PhotoViewModel
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public string Description { get; set; }
        public string Data { get; set; }
        public List<LikeViewModel> Likes { get; set; }
        public DateTime? UploadedDate { get; set; }
    }
}