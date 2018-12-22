using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using PhotoAlbum.DAL.EF;
using PhotoAlbum.DAL.Interfaces.IRepository;
using PhotoAlbum.DAL.Repositories.Base;
using PhotoAlbum.DAL.Entities;
using PhotoAlbum.DAL.Interfaces;

namespace PhotoAlbum.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public IPhotoRepository PhotoRepository { get; set; }
        public IClientProfilesRepository ClientProfilesRepository { get; set; }
        //public IGalleryRepository GalleryRepository { get; set; }

        //public IUserRepository UserRepository { get; set; }
        //public IRoleRepository RoleRepository { get; set; }
        private readonly PhotoAlbumContext _context;

        public UnitOfWork( PhotoAlbumContext context, 
                                IPhotoRepository photoRepository,
                                //IGalleryRepository galleryRepository, 
                                IClientProfilesRepository clientProfilesRepository,
                                IUserRepository userRepository,
                                IRoleRepository roleRepository)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            ClientProfilesRepository = clientProfilesRepository ?? throw new ArgumentNullException(nameof(clientProfilesRepository));
            PhotoRepository = photoRepository ?? throw new ArgumentNullException(nameof(photoRepository));
            //GalleryRepository = galleryRepository ?? throw new ArgumentNullException(nameof(galleryRepository));
            //UserRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            //RoleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            PhotoRepository?.Dispose();
            //GalleryRepository?.Dispose();
            //UserRepository?.Dispose();
            //RoleRepository?.Dispose();
            _context?.Dispose();
        }
    }
}