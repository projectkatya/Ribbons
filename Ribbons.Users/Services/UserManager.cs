using Ribbons.Data;
using Ribbons.Users.Data;
using Ribbons.Users.Services.Models;
using System;
using System.Threading.Tasks;

namespace Ribbons.Users.Services
{
    public class UserManager : IUserManager
        
    {
        protected IRelationalDbManager<UserDb> UserDbManager { get; }
        
        public UserManager(IRelationalDbManager<UserDb> userDbManager)
        {
            UserDbManager = userDbManager;
        }

        public Task<CreateUserTypeResponse> CreateUserTypeAsync(CreateUserTypeRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request)
        {
            UserDb db = await UserDbManager.GetDatabaseAsync();

            User user = new User
            {

            };

            return new CreateUserResponse();
        }
    }
}