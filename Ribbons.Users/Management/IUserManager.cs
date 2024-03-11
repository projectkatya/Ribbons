using Ribbons.Users.Management.Models;
using System.Threading.Tasks;

namespace Ribbons.Users.Management
{
    public interface IUserManager
    {
        Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request);
    }
}