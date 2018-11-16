using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.DAL.EF.Interfaces.IRepository;
using PhotoAlbum.DAL.EF.Repositories.Base;
using PhotoAlbum.DAL.EF.UoF.Base;

namespace PhotoAlbum.DAL.EF.UoF
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public IPhotoRepository PhotoRepository { get; set; }
        public IGalleryRepository GalleryRepository { get; set; }
        public IUserRepository UserRepository { get; set; }
        public IRoleRepository RoleRepository { get; set; }
        private readonly PhotoAlbumContext _context;

        public UnitOfWork( PhotoAlbumContext context, 
                                IPhotoRepository photoRepository,
                                IGalleryRepository galleryRepository, 
                                IUserRepository userRepository,
                                IRoleRepository roleRepository)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            PhotoRepository = photoRepository ?? throw new ArgumentNullException(nameof(photoRepository));
            GalleryRepository = galleryRepository ?? throw new ArgumentNullException(nameof(galleryRepository));
            UserRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            RoleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            PhotoRepository?.Dispose();
            GalleryRepository?.Dispose();
            UserRepository?.Dispose();
            RoleRepository?.Dispose();
            _context?.Dispose();
        }
    }
}