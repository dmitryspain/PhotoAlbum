using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using PhotoAlbum.BLL.Dtos;

namespace PhotoAlbum.BLL.Interfaces
{
    public interface IClientProfileService : IDisposable
    {
        Task<IdentityResult> SetAvatarAsync(int clientProfileId, byte[] avatar);
        Task<IdentityResult> ChangeDescriptionAsync(int clientProfileId, string description);
        Task<ClientProfileDto> GetProfileAsync(int userId); 
        Task<ClientProfileDto> FindByIdAsync(int clientProfileId);
    }
}
