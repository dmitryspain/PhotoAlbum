﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
    public class RoleService : IRoleService
    {
        private IIdentityUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public RoleService(IIdentityUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ApplicationRole, RoleDto>();
            }));
        }

        public IQueryable<RoleDto> Roles
        {
            get
            {
                throw new NotImplementedException();
                //var roles = _unitOfWork.RoleRepository.getq
                //return _mapper.Map<IQueryable<RoleDto>>(roles);
            }
        }

        public async Task<IdentityResult> CreateAsync(string roleName)
        {
            if (string.IsNullOrEmpty(roleName)) throw new ArgumentNullException(nameof(roleName));

            var role = await _unitOfWork.RoleRepository.FindByNameAsync(roleName);
            if (role != null)
                return IdentityResult.Failed("This roles already exists");

            return await _unitOfWork.RoleRepository.CreateAsync(new ApplicationRole(roleName));
        }

        public async Task<IdentityResult> DeleteAsync(string roleId)
        {
            if (string.IsNullOrEmpty(roleId)) throw new ArgumentNullException(nameof(roleId));

            var role = await _unitOfWork.RoleRepository.FindByIdAsync(roleId);
            return await _unitOfWork.RoleRepository.DeleteAsync(role);
        }

        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }

        public async Task<RoleDto> FindByIdAsync(string roleId)
        {
            if (string.IsNullOrEmpty(roleId)) throw new ArgumentNullException(nameof(roleId));
            var role = await _unitOfWork.RoleRepository.FindByIdAsync(roleId);

            return _mapper.Map<RoleDto>(role);
            
        }

        public async Task<IEnumerable<RoleDto>> GetAllAsync()
        {
            var roles = await _unitOfWork.RoleRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<RoleDto>>(roles);
        }

        public async Task<IEnumerable<RoleDto>> GetAllRolesAsync(Expression<Func<RoleDto, bool>> expression)
        {
            var expr = _mapper.Map<Expression<Func<ApplicationRole, bool>>>(expression 
                ?? throw new ArgumentNullException(nameof(expression)));

            var roles = await _unitOfWork.RoleRepository.GetAllAsync(expr);
            return _mapper.Map<IEnumerable<RoleDto>>(roles);
        }

        public async Task<IdentityResult> UpdateAsync(string roleId)
        {
            if (string.IsNullOrEmpty(roleId)) throw new ArgumentNullException(nameof(roleId));

            var role = await _unitOfWork.RoleRepository.FindByIdAsync(roleId);
            _unitOfWork.RoleRepository.Update(role);
            return IdentityResult.Success;
            /// ??????? shit?
        }
    }
}