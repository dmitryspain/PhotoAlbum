﻿using System;
using System.Collections.Generic;
using PhotoAlbum.BLL.Dtos.Base;

namespace PhotoAlbum.BLL.Dtos
{
    public class PhotoDto : EntityDto<int>
    {
        public int ClientProfileDtoId { get; set; }
        public string ImageName { get; set; }
        public string Description { get; set; }
        public string Data { get; set; }
        public List<LikeDto> Likes { get; set; } = new List<LikeDto>();
        public DateTime? UploadedDate { get; set; }
    }
}
