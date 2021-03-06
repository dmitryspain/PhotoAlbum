﻿using System.Collections.Generic;
using PhotoAlbum.BLL.Dtos.Base;

namespace PhotoAlbum.BLL.Dtos
{
    public class UserDto : EntityDto<int>
    {
        public IEnumerable<int> RolesId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int ClientProfileId { get; set; }
    }
}
