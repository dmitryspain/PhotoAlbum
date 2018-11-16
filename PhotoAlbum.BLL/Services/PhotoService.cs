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
    public class PhotoService : IPhotoService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public PhotoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

            _mapper = new Mapper(new MapperConfiguration(cfg => {
                cfg.CreateMap<Photo, PhotoDto>();
            }));
        }

        public async Task<IEnumerable<PhotoDto>> GetAllPhotosAsync()
        {
            var photos = await _unitOfWork.PhotoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PhotoDto>>(photos);
        }

        public async Task<IEnumerable<PhotoDto>> GetAllPhotosAsync(Expression<Func<PhotoDto, bool>> expression)
        {
            var expr = _mapper.Map<Expression<Func<Photo, bool>>>(expression);
            var photos = await _unitOfWork.PhotoRepository.GetAllAsync(expr);

            return _mapper.Map<IEnumerable<PhotoDto>>(photos);
        }

        public async Task<PhotoDto> GetSingleAsync(Expression<Func<PhotoDto, bool>> expression)
        {
            var expr = _mapper.Map<Expression<Func<Photo, bool>>>(expression);
            var photo = await _unitOfWork.PhotoRepository.GetSingleAsync(expr);

            return _mapper.Map<PhotoDto>(photo);
        }

        public async Task<IEnumerable<PhotoDto>> GetUserPhotosAsync(int? userId)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(userId);
            var photos = _unitOfWork.PhotoRepository.GetAllAsync(x => x.Gallery.User == user);

            return _mapper.Map<IEnumerable<PhotoDto>>(photos);
        }

        public async Task<IEnumerable<PhotoDto>> GetUserPhotosAsync(Expression<Func<UserDto, bool>> expression)
        {
            var expr = _mapper.Map<Expression<Func<User, bool>>>(expression);
            var user = await _unitOfWork.UserRepository.GetSingleAsync(expr);
            var photos = _unitOfWork.PhotoRepository.GetAllAsync(x => x.Gallery.User == user);
            return _mapper.Map<IEnumerable<PhotoDto>>(photos);
            // All is ok ???
        }

        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }
    }
}
