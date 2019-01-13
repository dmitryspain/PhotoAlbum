using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using PhotoAlbum.BLL.Dtos;

namespace PhotoAlbum.BLL.Interfaces
{
    public interface IClientProfileService
    {
        Task<IdentityResult> SetAvatarAsync(int clientProfileId, byte[] avatar);
        Task<IdentityResult> ChangeDescriptionAsync(ClientProfileDto clientProfile);
        Task<ClientProfileDto> GetProfileDataAsync(int userId); 
        Task<ClientProfileDto> FindByIdAsync(int clientProfileId);

    }
}
