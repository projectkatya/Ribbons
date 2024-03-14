using Microsoft.AspNetCore.Http;
using Ribbons.Users.Authentication.Models;
using System;
using System.Threading.Tasks;

namespace Ribbons.Users.Authentication
{
    public interface IUserAuthenticator<TUserType> where TUserType : Enum
    {
        Task<LoginResponse> LoginAsync(TUserType userType, LoginRequest loginRequest, HttpResponse httpResponse);
        Task LogoutAsync(TUserType userType);
        Task RecoverPasswordAsync(TUserType userType);
        Task ResetPasswordAsync(TUserType userType);
    }
}