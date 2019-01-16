﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;
using PhotoAlbum.DAL.Entities.Base;

namespace PhotoAlbum.DAL.Entities
{
    public class ClientProfile : Entity<int>
    {
        public string Description { get; set; }
        public virtual byte[] Avatar { get; set; }
        public virtual ICollection<Photo> Photos { get; set; } = new List<Photo>();
    }
}
