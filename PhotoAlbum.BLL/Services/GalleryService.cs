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
using PhotoAlbum.DAL.Interfaces;

namespace PhotoAlbum.BLL.Services
{
    public class GalleryService : IGalleryService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public GalleryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

            _mapper = new Mapper(new MapperConfiguration(cfg => {
                cfg.CreateMap<Gallery, GalleryDto>();
            }));
        }

        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }

        public async Task<GalleryDto> GetGalleryAsync()
        {
            var gallery = await _unitOfWork.GalleryRepository.GetByIdAsync(1);
            
            return await _mapper.Map<Task<GalleryDto>>(gallery ??
                throw new ArgumentNullException(nameof(gallery)));
        }

        //public Task<GalleryDto> GetSingleAsync(Expression<Func<GalleryDto, bool>> expression)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
