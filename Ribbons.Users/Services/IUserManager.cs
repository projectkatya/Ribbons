using Microsoft.Extensions.Hosting;
using Ribbons.Users.Services.Models;
using System.Threading.Tasks;

namespace Ribbons.Users.Services
{
    public interface IUserManager : IHostedService
    {
        Task<CreateUserScopeResponse> CreateUserScopeAsync(UserScope userScope);
        Task<EditUserScopeResponse> EditUserScopeAsync(UserScope userScope);
        Task<CreateUserScopeAliasResponse> CreateUserScopeAliasAsync(UserScopeAlias userScopeAlias);
        Task<EditUserScopeAliasResponse> EditUserScopeAliasAsync(UserScopeAlias userScopeAlias);
        Task CreateUserTypeAsync(UserType userType);
    }
}