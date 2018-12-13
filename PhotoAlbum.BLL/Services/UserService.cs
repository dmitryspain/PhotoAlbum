using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Identity;
using PhotoAlbum.BLL.Dtos;
using PhotoAlbum.BLL.Interfaces;
using PhotoAlbum.DAL.Entities;
using PhotoAlbum.DAL.Interfaces;

namespace PhotoAlbum.BLL.Services
{

    public class UserService : IUserService
    {
        private IIdentityUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public UserService(IIdentityUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

            _mapper = new Mapper(new MapperConfiguration(cfg => {
                cfg.CreateMap<ApplicationUser, UserDto>();
            }));
        }

        public IQueryable<UserDto> Users
        {
            get
            {
                var users = _unitOfWork.UserRepository.GetAll();
                return _mapper.Map<IQueryable<UserDto>>(users);
            }
        }

        public async Task<IdentityResult> AddToRoleAsync(string userId, string role)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(role))
                return IdentityResult.Failed("userId or role can't be null or empty");

            var user = _unitOfWork.UserRepository.FindByIdAsync(userId);

            if (!await _unitOfWork.RoleRepository.RoleExistsAsync(role))
                return IdentityResult.Failed("This role isn't exists");
            else
                return await _unitOfWork.UserRepository.AddToRoleAsync(userId, role);
        }

        public async Task<IdentityResult> CreateAsync(UserDto userDto, string password)
        {
            // todo finish this one
            var newUser = await _unitOfWork.UserRepository.GetSingleAsync(x => x.UserName == userDto.UserName);

            if(newUser != null)
            {
                return IdentityResult.Failed("This user already exists!");
            }

            newUser = new ApplicationUser { Email = userDto.Email, UserName = userDto.UserName };
            var result =  await _unitOfWork.UserRepository.CreateAsync(newUser, password);

            if(result.Errors?.Count() > 0)
            {
                return IdentityResult.Failed(result.Errors.FirstOrDefault());
            }

            if(await _unitOfWork.RoleRepository.RoleExistsAsync("Users"))
                return await AddToRoleAsync(newUser.Id, "Users");

            result = await _unitOfWork.RoleRepository.CreateAsync(new ApplicationRole("Users"));
            if (result.Errors?.Count() > 0)
                return new IdentityResult(result.Errors.FirstOrDefault());

            return await AddToRoleAsync(newUser.Id, "Users");
        }

        public async Task<ClaimsIdentity> CreateIdentityAsync(UserDto user, string authenticationType)
        {
            if (string.IsNullOrEmpty(authenticationType)) throw new ArgumentNullException(nameof(authenticationType));

            var appUser = await _unitOfWork.UserRepository.FindByIdAsync(user.Id ?? throw new ArgumentNullException(nameof(user)));
            if (appUser == null) return null;

            return await _unitOfWork.UserRepository.CreateIdentityAsync(appUser, authenticationType);
        }

        public async Task<IdentityResult> DeleteAsync(string userId)
        {
            var user = await _unitOfWork.UserRepository.FindByIdAsync(userId);
            return await _unitOfWork.UserRepository.DeleteAsync(user ?? throw new ArgumentNullException(nameof(user)));
        }

        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }

        public async Task<UserDto> FindAsync(string userName, string password)
        {
            var user = await _unitOfWork.UserRepository.FindAsync(userName, password);
            return _mapper.Map<UserDto>(user); 
        }

        public async Task<UserDto> FindByIdAsync(string userId)
        {
            var user = await _unitOfWork.UserRepository.FindByIdAsync(userId);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var user = await _unitOfWork.UserRepository.GetAllAsync();
            return _mapper.Map<List<UserDto>>(user);
        }

        public List<UserDto> GetAll()
        {
            var user = _unitOfWork.UserRepository.GetAll();
            return _mapper.Map<List<UserDto>>(user);
        }

        public async Task<IdentityResult> RemoveFromRoleAsync(string userId, string role)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(role))
                return IdentityResult.Failed("One of parametrs was empty or null");

            var user = _unitOfWork.UserRepository.FindByIdAsync(userId);

            if (user == null)
                return IdentityResult.Failed("This user isn't exists");

            if (!await _unitOfWork.RoleRepository.RoleExistsAsync(role))
                return IdentityResult.Failed("Role isn't exists");

            return await _unitOfWork.UserRepository.RemoveFromRoleAsync(userId, role);
        }

        public async Task<IdentityResult> UpdateAsync(UserDto user)
        {
            var appUser = _mapper.Map<ApplicationUser>(user ?? throw new ArgumentNullException(nameof(user)));
            return await _unitOfWork.UserRepository.UpdateAsync(appUser);
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
