using Microsoft.AspNetCore.Http;
using Ribbons.Users.Authentication.Models;
using System.Threading.Tasks;

namespace Ribbons.Users.Authentication
{
    public interface IUserAuthenticator
    {
        IUserAuthenticator SetHttpContext(HttpRequest httpRequest, HttpResponse httpResponse);
        Task<LoginResponse> LoginAsync(LoginRequest loginRequest);
        Task LogoutAsync();
        Task RecoverPasswordAsync();
        Task ResetPasswordAsync();
    }
}