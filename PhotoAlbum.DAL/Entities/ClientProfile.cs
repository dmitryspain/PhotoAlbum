using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;
using PhotoAlbum.DAL.EF.Models;
using PhotoAlbum.DAL.Entities.Base;

namespace PhotoAlbum.DAL.Entities
{
    public class ClientProfile : Entity<string>
    {
        public string Description { get; set; }
        public DateTime? DateOfBirdth { get; set; }

        public string GalleryId { get; set; }
        public virtual Gallery Gallery { get; set; }

        [Key, ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
