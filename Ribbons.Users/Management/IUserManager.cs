using Ribbons.Users.Management.Models;
using System;
using System.Threading.Tasks;

namespace Ribbons.Users.Management
{
    public interface IUserManager<TUserType> where TUserType : Enum
    {
        Task<CreateUserResponse> CreateUserAsync(TUserType userType, CreateUserRequest request);
    }
}