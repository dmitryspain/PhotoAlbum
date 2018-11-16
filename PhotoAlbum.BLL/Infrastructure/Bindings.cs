using Ninject.Modules;
using PhotoAlbum.BLL.Interfaces;
using PhotoAlbum.BLL.Services;
using PhotoAlbum.DAL.EF;
using PhotoAlbum.DAL.EF.Interfaces.IRepository;
using PhotoAlbum.DAL.EF.Repositories;
using PhotoAlbum.DAL.EF.UoF;
using PhotoAlbum.DAL.EF.UoF.Base;

namespace PhotoAlbum.BLL.Infrastructure
{
    public class Bindings : NinjectModule
    {
        private readonly string _connectionString;
        public Bindings(string connectionString) => _connectionString = connectionString;

        public override void Load()
        {
            Bind<IPhotoService>().To<PhotoService>();
            Bind<IUserService>().To<UserService>();
            Bind<IGalleryService>().To<GalleryService>();
            Bind<IRoleService>().To<RoleService>();

            Bind<IRoleRepository>().To<RoleRepository>();
            Bind<IUserRepository>().To<UserRepository>();
            Bind<IPhotoRepository>().To<PhotoRepository>();
            Bind<IGalleryRepository>().To<GalleryRepository>();

            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<PhotoAlbumContext>().ToSelf().WithConstructorArgument(_connectionString);
        }
    }
}
