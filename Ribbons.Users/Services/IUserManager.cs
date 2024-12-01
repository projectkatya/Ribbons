using Ribbons.Users.Services.Models;
using System.Threading.Tasks;

namespace Ribbons.Users.Services
{
    public interface IUserManager
    {
        Task CreateUserTypeAsync(UserType userType);
        Task CreateUserAttributeTypeAsync(UserAttributeType userAttributeType);
    }
}