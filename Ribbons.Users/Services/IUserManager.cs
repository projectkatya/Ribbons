using Ribbons.Users.Services.Models;
using System;
using System.Threading.Tasks;

namespace Ribbons.Users.Services
{
    public interface IUserManager
    {
        Task<CreateUserTypeResponse> CreateUserTypeAsync(CreateUserTypeRequest request);
        Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request);
    }
}