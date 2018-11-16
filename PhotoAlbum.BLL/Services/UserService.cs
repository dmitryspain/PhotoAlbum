using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PhotoAlbum.BLL.Dtos;
using PhotoAlbum.BLL.Interfaces;
using PhotoAlbum.DAL.EF.Models;
using PhotoAlbum.DAL.EF.UoF.Base;

namespace PhotoAlbum.BLL.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

            _mapper = new Mapper(new MapperConfiguration(cfg => {
                cfg.CreateMap<User, UserDto>();
            }));
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _unitOfWork.UserRepository.GetAllAsync();
            return  _mapper.Map<IEnumerable<UserDto>>(users ?? 
                throw new ArgumentNullException(nameof(users)));

        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync(Expression<Func<UserDto, bool>> expression)
        {
            var expr = _mapper.Map<Expression<Func<User, bool>>>(expression);
            var users = await _unitOfWork.UserRepository.GetAllAsync(expr);

            return _mapper.Map<IEnumerable<UserDto>>(users ??
                throw new ArgumentNullException(nameof(users)));
        }

        public async Task<UserDto> GetSingleAsync(Expression<Func<UserDto, bool>> expression)
        {
            var expr = _mapper.Map<Expression<Func<User, bool>>>(expression);
            var user = await _unitOfWork.UserRepository.GetSingleAsync(expr);

            return _mapper.Map<UserDto>(user ??
                throw new ArgumentNullException(nameof(user)));
        }

        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }
    }
}
