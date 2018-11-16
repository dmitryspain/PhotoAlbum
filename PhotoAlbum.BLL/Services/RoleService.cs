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
    public class RoleService : IRoleService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

            _mapper = new Mapper(new MapperConfiguration(cfg => {
                cfg.CreateMap<Role, RoleDto>();
            }));
        }

        public async Task<IEnumerable<RoleDto>> GetAllRolesAsync()
        {
            var roles = await _unitOfWork.RoleRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<RoleDto>>(roles);
        }

        public async Task<IEnumerable<RoleDto>> GetAllRolesAsync(Expression<Func<RoleDto, bool>> expression)
        {
            var expr = _mapper.Map<Expression<Func<Role, bool>>>(expression);
            var roles = await _unitOfWork.RoleRepository.GetAllAsync(expr);

            return _mapper.Map<IEnumerable<RoleDto>>(roles);
        }

        public async Task<RoleDto> GetSingleAsync(Expression<Func<RoleDto, bool>> expression)
        {
            var expr = _mapper.Map<Expression<Func<Role, bool>>>(expression);
            var role = await _unitOfWork.RoleRepository.GetSingleAsync(expr);

            return _mapper.Map<RoleDto>(role);
        }

        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }
    }
}
