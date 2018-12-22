using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Identity;
using PhotoAlbum.BLL.Dtos;
using PhotoAlbum.BLL.Interfaces;
using PhotoAlbum.Constans;
using PhotoAlbum.DAL.Entities;
using PhotoAlbum.DAL.Interfaces;

namespace PhotoAlbum.BLL.Services
{

    public class UserService : IUserService
    {
        private IIdentityUnitOfWork _identityUnitOfWork;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public UserService(IIdentityUnitOfWork identityUnitOfWork, IUnitOfWork unitOfWork)
        {
            _identityUnitOfWork = identityUnitOfWork ?? throw new ArgumentNullException(nameof(identityUnitOfWork));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

            _mapper = new Mapper(new MapperConfiguration(cfg => {
                cfg.CreateMap<ApplicationUser, UserDto>();
            }));
        }

        public IQueryable<UserDto> Users
        {
            get
            {
                var users = _identityUnitOfWork.UserRepository.GetAll();
                return _mapper.Map<IQueryable<UserDto>>(users);
            }
        }

        public async Task<IdentityResult> AddToRoleAsync(int userId, string role)
        {
            //if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(role))
                //return IdentityResult.Failed("userId or role can't be null or empty");

            var user = _identityUnitOfWork.UserRepository.FindByIdAsync(userId);

            if (!await _identityUnitOfWork.RoleRepository.RoleExistsAsync(role))
                return IdentityResult.Failed("This role isn't exists");
            else
                return await _identityUnitOfWork.UserRepository.AddToRoleAsync(userId, role);
        }

        public async Task<IdentityResult> CreateAsync(UserDto userDto, string password)
        {
            var newUser = await _identityUnitOfWork.UserRepository.GetSingleAsync(x => x.UserName == userDto.UserName);

            if(newUser != null)
            {
                return IdentityResult.Failed("This user already exists!");
            }

            newUser = new ApplicationUser { Email = userDto.Email, UserName = userDto.UserName };
            var clientProfile = new ClientProfile
            {
                Description = "UserServiceClient"
            };
            var photo = new Photo
            {
                Description = "UserServiceClientPhoto[Test]"
            };

            _unitOfWork.ClientProfilesRepository.Create(clientProfile);
            photo.ClientProfileId = clientProfile.Id;
            _unitOfWork.PhotoRepository.Create(photo);

            newUser.ClientProfileId = clientProfile.Id;
            var result =  await _identityUnitOfWork.UserRepository.CreateAsync(newUser, password);

            if(result.Errors?.Count() > 0)
            {
                return IdentityResult.Failed(result.Errors.FirstOrDefault());
            }

            if (await _identityUnitOfWork.RoleRepository.RoleExistsAsync(RoleName.User))
                return await AddToRoleAsync(newUser.Id, RoleName.User);

            result = await _identityUnitOfWork.RoleRepository.CreateAsync(new ApplicationRole(RoleName.User));
            if (result.Errors?.Count() > 0)
                return new IdentityResult(result.Errors.FirstOrDefault());

            return await AddToRoleAsync(newUser.Id, RoleName.User);

        }

        public async Task<ClaimsIdentity> CreateIdentityAsync(UserDto user, string authenticationType)
        {
            if (string.IsNullOrEmpty(authenticationType)) throw new ArgumentNullException(nameof(authenticationType));

            //var appUser = await _identityUnitOfWork.UserRepository.FindByIdAsync(user.Id ?? throw new ArgumentNullException(nameof(user)));
            var appUser = await _identityUnitOfWork.UserRepository.FindByIdAsync(user.Id);
            if (appUser == null) return null;

            return await _identityUnitOfWork.UserRepository.CreateIdentityAsync(appUser, authenticationType);
        }

        public async Task<IdentityResult> DeleteAsync(int userId)
        {
            var user = await _identityUnitOfWork.UserRepository.FindByIdAsync(userId);
            return await _identityUnitOfWork.UserRepository.DeleteAsync(user ?? throw new ArgumentNullException(nameof(user)));
        }

        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }

        public async Task<UserDto> FindAsync(string userName, string password)
        {
            var user = await _identityUnitOfWork.UserRepository.FindAsync(userName, password);
            return _mapper.Map<UserDto>(user); 
        }

        public async Task<UserDto> FindByIdAsync(int userId)
        {
            var user = await _identityUnitOfWork.UserRepository.FindByIdAsync(userId);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var user = await _identityUnitOfWork.UserRepository.GetAllAsync();
            return _mapper.Map<List<UserDto>>(user);
        }

        public List<UserDto> GetAll()
        {
            var user = _identityUnitOfWork.UserRepository.GetAll();
            return _mapper.Map<List<UserDto>>(user);
        }

        public async Task<IdentityResult> RemoveFromRoleAsync(int userId, string role)
        {
            //if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(role))
            //    return IdentityResult.Failed("One of parametrs was empty or null");

            var user = _identityUnitOfWork.UserRepository.FindByIdAsync(userId);

            if (user == null)
                return IdentityResult.Failed("This user isn't exists");

            if (!await _identityUnitOfWork.RoleRepository.RoleExistsAsync(role))
                return IdentityResult.Failed("Role isn't exists");

            return await _identityUnitOfWork.UserRepository.RemoveFromRoleAsync(userId, role);
        }

        public async Task<IdentityResult> UpdateAsync(UserDto user)
        {
            var appUser = _mapper.Map<ApplicationUser>(user ?? throw new ArgumentNullException(nameof(user)));
            return await _identityUnitOfWork.UserRepository.UpdateAsync(appUser);
        }

        public async Task<IList<string>> GetRolesAsync(int userId)
        {
            return await _identityUnitOfWork.UserRepository.GetRolesAsync(userId);
        }
    }


    //public class UserService : IUserService
    //{
    //    private IUnitOfWork _unitOfWork;
    //    private IMapper _mapper;

    //    public UserService(IUnitOfWork unitOfWork)
    //    {
    //        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

    //        _mapper = new Mapper(new MapperConfiguration(cfg => {
    //            cfg.CreateMap<ApplicationUser, UserDto>();
    //        }));
    //    }

    //    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    //    {
    //        var users = await _unitOfWork.UserRepository.GetAllAsync();
    //        return  _mapper.Map<IEnumerable<UserDto>>(users ?? 
    //            throw new ArgumentNullException(nameof(users)));

    //    }

    //    public async Task<IEnumerable<UserDto>> GetAllUsersAsync(Expression<Func<UserDto, bool>> expression)
    //    {
    //        var expr = _mapper.Map<Expression<Func<ApplicationUser, bool>>>(expression);
    //        var users = await _unitOfWork.UserRepository.GetAllAsync(expr);

    //        return _mapper.Map<IEnumerable<UserDto>>(users ??
    //            throw new ArgumentNullException(nameof(users)));
    //    }

    //    public IEnumerable<UserDto> GetAllUsers()
    //    {
    //        var users = _unitOfWork.UserRepository.GetAll();
    //        return _mapper.Map<IEnumerable<UserDto>>(users ??
    //            throw new ArgumentNullException(nameof(users)));
    //    }


    //    public async Task<UserDto> GetSingleAsync(Expression<Func<UserDto, bool>> expression)
    //    {
    //        var expr = _mapper.Map<Expression<Func<ApplicationUser, bool>>>(expression);
    //        var user = await _unitOfWork.UserRepository.GetSingleAsync(expr);

    //        return _mapper.Map<UserDto>(user ??
    //            throw new ArgumentNullException(nameof(user)));
    //    }

    //    public void Dispose()
    //    {
    //        _unitOfWork?.Dispose();
    //    }
    //}
}
