using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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

        public async Task<IdentityResult> CreateAsync(string roleName)
        {
            if (string.IsNullOrEmpty(roleName)) throw new ArgumentNullException(nameof(roleName));

            var role = await _unitOfWork.RoleRepository.FindByNameAsync(roleName);
            if (role != null)
                return IdentityResult.Failed("This roles already exists");

            try
            {

                await _unitOfWork.RoleRepository.CreateAsync(new ApplicationRole(roleName));
            }
            catch(DbUpdateException ex)
            {
                throw new ArgumentException("Role isn't created!" + ex.Message, ex.InnerException);
            }

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(int roleId)
        {
            var role = await _unitOfWork.RoleRepository.FindByIdAsync(roleId);
            return await _unitOfWork.RoleRepository.DeleteAsync(role);
        }

        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }

        public RoleDto FindById(int roleId)
        {
            var role = _unitOfWork.RoleRepository.FindById(roleId);
            return _mapper.Map<RoleDto>(role ?? throw new ArgumentException("No role with that id"));
        }

        public async Task<RoleDto> FindByIdAsync(int roleId)
        {
            var role = await _unitOfWork.RoleRepository.FindByIdAsync(roleId);

            return _mapper.Map<RoleDto>(role ?? throw new ArgumentException("No role with that id"));
            
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

        public async Task<IdentityResult> UpdateAsync(int roleId)
        {
            //if (string.IsNullOrEmpty(roleId)) throw new ArgumentNullException(nameof(roleId));

            var role = await _unitOfWork.RoleRepository.FindByIdAsync(roleId);
            _unitOfWork.RoleRepository.Update(role);
            return IdentityResult.Success;
            /// ??????? shit?
        }
    }
}