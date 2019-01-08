using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.BLL.Dtos;

namespace PhotoAlbum.BLL.Interfaces
{
    public interface IClientProfileService
    {
        Task SetAvatar(int clientProfileId, PhotoDto avatar);
        Task<ClientProfileDto> GetProfileData(int userId); 
        Task<ClientProfileDto> FindByIdAsync(int clientProfileId);
    }
}
