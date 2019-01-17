using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PhotoAlbum.BLL.Dtos;
using PhotoAlbum.BLL.Interfaces;
using PhotoAlbum.DAL.Entities;
using PhotoAlbum.DAL.Interfaces;

namespace PhotoAlbum.BLL.Services
{
    public class PhotoService : IPhotoService
    {
        private IUnitOfWork _unitOfWork;
        private IIdentityUnitOfWork _identityUnitOfWork;
        private IMapper _mapper;

        public PhotoService(IUnitOfWork unitOfWork, IIdentityUnitOfWork identityUnitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _identityUnitOfWork = identityUnitOfWork ?? throw new ArgumentNullException(nameof(identityUnitOfWork));

            _mapper = new Mapper(new MapperConfiguration(cfg => {
                cfg.CreateMap<Photo, PhotoDto>()
                .ForMember(x => x.ClientProfileDtoId, opt => opt.MapFrom(x => x.ClientProfileId))
                .ForMember(x => x.Data, opt=> opt.MapFrom(x => Convert.ToBase64String(x.Data)));
                cfg.CreateMap<Like, LikeDto>()
                .ForMember(x => x.PhotoDtoId, opt => opt.MapFrom(x => x.PhotoId));
            }));
        }

        public async Task<IEnumerable<PhotoDto>> GetAllPhotosAsync()
        {
            var photos = await _unitOfWork.PhotoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PhotoDto>>(photos);
        }

        public async Task<IEnumerable<PhotoDto>> GetUserPhotosAsync(int userId)
        {
            var user = await _identityUnitOfWork.UserRepository.GetByIdAsync(userId);
            var photos = await _unitOfWork.PhotoRepository.GetAllAsync(x => x.ClientProfileId == user.ClientProfileId);

            return _mapper.Map<IEnumerable<PhotoDto>>(photos);
        }


        public IEnumerable<PhotoDto> GetAllPhotos()
        {
            var photos = _unitOfWork.PhotoRepository.GetAll();
            return _mapper.Map<IEnumerable<PhotoDto>>(photos);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
            _identityUnitOfWork.Dispose();
        }

        public async Task UploadPhotoAsync(int userId, byte[] data, string description)
        {
            var user = await _identityUnitOfWork.UserRepository.FindByIdAsync(userId);
            var imageName = $"img_{DateTime.Now.ToString("yymmssfff")}";

            Photo photo = new Photo()
            {
                ClientProfileId = user.ClientProfileId,
                Data = data,
                Description = description,
                ImageName = imageName,
                UploadedDate = DateTime.Now,
            };

            _unitOfWork.PhotoRepository.Create(photo);
        }

        public async Task<PhotoDto> GetPhotoByIdAsync(int photoId)
        {
            var photo = await _unitOfWork.PhotoRepository.GetByIdAsync(photoId);
            return _mapper.Map<PhotoDto>(photo);
        }

        public void RemovePhoto(int photoId)
        {
           _unitOfWork.PhotoRepository.Delete(photoId);
        }

        public async Task LikeAsync(int photoId, int userId)
        {
            var photo = await _unitOfWork.PhotoRepository.GetByIdAsync(photoId);
            if (photo == null)
                throw new ArgumentException("No photo with that id");

            var user = await _identityUnitOfWork.UserRepository.FindByIdAsync(userId);

            var like = new Like()
            {
                PhotoId = photoId,
                UserName = user.UserName
            };

            var existingLike = photo.Likes.FirstOrDefault(x => x.PhotoId == photoId && x.UserName == user.UserName);

            if (existingLike == null)
            {
                photo.Likes.Add(like);
                _unitOfWork.PhotoRepository.Update(photo);
            }
            else
            {
                _unitOfWork.LikeRepository.Delete(existingLike.Id);
                photo.Likes.Remove(existingLike);
            }
        }
    }
}
