﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PhotoAlbum.BLL.Dtos;
using PhotoAlbum.BLL.Interfaces;
using PhotoAlbum.DAL.Entities;
using PhotoAlbum.DAL.Interfaces;

namespace PhotoAlbum.BLL.Services
{
    public class ClientProfileService : IClientProfileService
    {
        private IUnitOfWork _unitOfWork;
        private IIdentityUnitOfWork _identityUnitOfWork;
        private IMapper _mapper;

        public ClientProfileService(IUnitOfWork unitOfWork, IIdentityUnitOfWork identityUnitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _identityUnitOfWork = identityUnitOfWork ?? throw new ArgumentNullException(nameof(identityUnitOfWork));

            _mapper = new Mapper(new MapperConfiguration(cfg => {
                cfg.CreateMap<ClientProfile, ClientProfileDto>().
                ForMember(x=> x.Avatar, opt => opt.MapFrom(x => Convert.ToBase64String(x.Avatar)));
                cfg.CreateMap<Photo, PhotoDto>()
                .ForMember(x => x.Data, opt => opt.MapFrom(x => Convert.ToBase64String(x.Data)));

            }));
        }

        public async Task SetAvatar(int clientProfileId, PhotoDto avatar)
        {
            var clientProfile = await _unitOfWork.ClientProfilesRepository.GetByIdAsync(clientProfileId);
            clientProfile.Avatar = Convert.FromBase64String(avatar.Data);

            _unitOfWork.ClientProfilesRepository.Update(clientProfile);
            Debug.WriteLine("AvatarLength = " + clientProfile.Avatar.Length);
        }

        public async Task<ClientProfileDto> GetProfileData(UserDto userDto)
        {
            try
            {
                //var user = await _identityUnitOfWork.UserRepository.FindAsync("qwerty", "qwerty123");
                var user = _identityUnitOfWork.UserRepository.GetById(userDto.Id);
                var clientProfile = user.ClientProfile;//await _unitOfWork.ClientProfilesRepository.GetByIdAsync(clientProfileId);
                return _mapper.Map<ClientProfileDto>(clientProfile);

            }
            catch(Exception ex)
            {

            }
            return null;
        }

        public async Task<ClientProfileDto> FindByIdAsync(int clientProfileId)
        {
            var profile = await _unitOfWork.ClientProfilesRepository.GetByIdAsync(clientProfileId);
            return _mapper.Map<ClientProfileDto>(profile);
        }
    }
}