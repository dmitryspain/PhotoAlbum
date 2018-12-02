﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.BLL.Dtos;

namespace PhotoAlbum.BLL.Interfaces
{
    public interface IPhotoService : IDisposable
    {
        Task<IEnumerable<PhotoDto>> GetAllPhotosAsync();
        IEnumerable<PhotoDto> GetAllPhotos();
        Task<IEnumerable<PhotoDto>> GetUserPhotosAsync(int? userId);
        Task<IEnumerable<PhotoDto>> GetAllPhotosAsync(Expression<Func<PhotoDto, bool>> expression);
        Task<IEnumerable<PhotoDto>> GetUserPhotosAsync(Expression<Func<UserDto, bool>> expression);
        Task<PhotoDto> GetSingleAsync(Expression<Func<PhotoDto, bool>> expression);
    }
}