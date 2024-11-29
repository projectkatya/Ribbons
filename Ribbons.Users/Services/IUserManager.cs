using Ribbons.Users.Definitions;
using System.Threading.Tasks;

namespace Ribbons.Users.Services
{
    public interface IUserManager
    {
        Task<UserType> CreateUserTypeAsync(string code, string name, string description = null);
        Task<UserAttributeType> CreateUserAttributeTypeAsync(string userType, string code, string name, UserAttributeValueType valueType, string description = null);
        Task<UserCredentialType> CreateUserCredentialTypeAsync(string userType, string code, string name, string description = null);
        Task<UserTokenType> CreateUserTokenTypeAsync(string userType, string code, string name, string description = null);
        Task<UserStatus> CreateUserStatusAsync(string userType, string code, string name, string description = null);
    }
}