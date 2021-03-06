﻿using Ninject.Modules;
using PhotoAlbum.DAL.EF;
using PhotoAlbum.DAL.Interfaces;
using PhotoAlbum.DAL.Interfaces.IRepository;
using PhotoAlbum.DAL.Repositories;

namespace PhotoAlbum.BLL.Infrastructure
{
    public class Bindings : NinjectModule
    {
        private readonly string _connectionString;
        public Bindings(string connectionString) => _connectionString = connectionString;

        public override void Load()
        {
            Bind<IClientProfilesRepository>().To<ClientProfileRepository>();
            Bind<IRoleRepository>().To<RoleRepository>();
            Bind<IUserRepository>().To<UserRepository>();
            Bind<IPhotoRepository>().To<PhotoRepository>();
            Bind<ILikeRepository>().To<LikeRepository>();

            Bind<IIdentityUnitOfWork>().To<IdentityUnitOfWork>();
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<PhotoAlbumContext>().ToSelf().WithConstructorArgument(_connectionString);
        }
    }
}
