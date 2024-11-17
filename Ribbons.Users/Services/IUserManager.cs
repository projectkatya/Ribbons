using Ribbons.Users.Services.Models;
using System.Threading.Tasks;

namespace Ribbons.Users.Services
{
    public interface IUserManager
    {
        Task<CreateUserTypeResponse> CreateUserTypeAsync(CreateUserTypeRequest request);
        Task<CreateUserStatusResponse> CreateUserStatusAsync(CreateUserStatusRequest request);
        Task<CreateUserTokenTypeResponse> CreateUserTokenTypeAsync(CreateUserTokenTypeRequest request);
        Task<CreateUserGroupResponse> CreateUserGroupAsync(CreateUserGroupRequest request);
        Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request);
    }
}