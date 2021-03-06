﻿using System;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Identity;
using PhotoAlbum.BLL.Dtos;
using PhotoAlbum.BLL.Interfaces;
using PhotoAlbum.DAL.Entities;
using PhotoAlbum.DAL.Interfaces;

namespace PhotoAlbum.BLL.Services
{
    public class ClientProfileService : IClientProfileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IIdentityUnitOfWork _identityUnitOfWork;
        private readonly IMapper _mapper;

        public ClientProfileService(IUnitOfWork unitOfWork, IIdentityUnitOfWork identityUnitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _identityUnitOfWork = identityUnitOfWork ?? throw new ArgumentNullException(nameof(identityUnitOfWork));

            _mapper = new Mapper(new MapperConfiguration(cfg => {
                cfg.CreateMap<ClientProfile, ClientProfileDto>().
                ForMember(x=> x.Avatar, opt => opt.MapFrom(x => Convert.ToBase64String(x.Avatar)));
                cfg.CreateMap<Photo, PhotoDto>()
                .ForMember(x => x.Data, opt => opt.MapFrom(x => Convert.ToBase64String(x.Data)))
                .ForMember(x => x.ClientProfileDtoId, opt => opt.MapFrom(x => x.ClientProfileId))
                .ReverseMap().ForMember(x=>x.ClientProfile, opt => opt.Ignore());
                
                cfg.CreateMap<Like, LikeDto>()
                .ForMember(x => x.PhotoDtoId, opt => opt.MapFrom(x => x.PhotoId));
            }));
        }

        public async Task<IdentityResult> SetAvatarAsync(int clientProfileId, byte[] avatar)
        {
            try
            {
                var clientProfile = await _unitOfWork.ClientProfilesRepository.GetByIdAsync(clientProfileId);
                clientProfile.Avatar = avatar;

                _unitOfWork.ClientProfilesRepository.Update(clientProfile);
            }
            catch (DbUpdateException ex)
            {
                return IdentityResult.Failed("Couldn't change client profile avatar!", ex.Message, ex.InnerException?.Message);
            }

            return IdentityResult.Success;
        }

        public async Task<ClientProfileDto> GetProfileAsync(int userId)
        {
            var user = await _identityUnitOfWork.UserRepository.GetByIdAsync(userId);
            var clientProfile = user.ClientProfile;
            return _mapper.Map<ClientProfileDto>(clientProfile);
        }

        public async Task<ClientProfileDto> FindByIdAsync(int clientProfileId)
        {
            var profile = await _unitOfWork.ClientProfilesRepository.GetByIdAsync(clientProfileId);
            return _mapper.Map<ClientProfileDto>(profile);
        }

        public async Task<IdentityResult> ChangeDescriptionAsync(int clientProfileId, string description)
        {
            var clientProfile = await _unitOfWork.ClientProfilesRepository.GetByIdAsync(clientProfileId);
            clientProfile.Description = description;

            try
            {
                _unitOfWork.ClientProfilesRepository.Update(clientProfile);
            }
            catch (DbUpdateException ex)
            {
                return IdentityResult.Failed("Couldn't change client profile description!", ex.Message, ex.InnerException?.Message);
            }

            return IdentityResult.Success;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
            _identityUnitOfWork.Dispose();
        }
    }
}
