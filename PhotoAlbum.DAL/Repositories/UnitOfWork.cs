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
        public ILikeRepository LikeRepository { get; set; }
        public IClientProfilesRepository ClientProfilesRepository { get; set; }
        private readonly PhotoAlbumContext _context;
        public UnitOfWork( PhotoAlbumContext context, 
                                IPhotoRepository photoRepository,
                                IClientProfilesRepository clientProfilesRepository, 
                                ILikeRepository likeRepository)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            ClientProfilesRepository = clientProfilesRepository ?? throw new ArgumentNullException(nameof(clientProfilesRepository));
            PhotoRepository = photoRepository ?? throw new ArgumentNullException(nameof(photoRepository));
            LikeRepository = likeRepository ?? throw new ArgumentNullException(nameof(likeRepository));
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            PhotoRepository?.Dispose();
            LikeRepository?.Dispose();
            ClientProfilesRepository.Dispose();
            _context?.Dispose();
        }
    }
}