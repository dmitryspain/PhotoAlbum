using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.DAL.EF;
using PhotoAlbum.DAL.Interfaces;
using PhotoAlbum.DAL.Interfaces.IRepository;

namespace PhotoAlbum.DAL.Repositories
{
    public class IdentityUnitOfWork : IIdentityUnitOfWork
    {
        private PhotoAlbumContext _context;
        public IUserRepository UserRepository { get; set; }
        public IRoleRepository RoleRepository { get; set; }

        public IdentityUnitOfWork(PhotoAlbumContext context, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

            UserRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            RoleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
