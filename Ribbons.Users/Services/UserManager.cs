using Microsoft.EntityFrameworkCore;
using Ribbons.Data;
using Ribbons.Users.Data;
using Ribbons.Users.Services.Models;
using System;
using System.Linq;
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

        public async Task<CreateUserTypeResponse> CreateUserTypeAsync(CreateUserTypeRequest request)
        {
            UserDb db = await UserDbManager.GetDatabaseAsync();

            if (await db.UserTypes.AnyAsync(x => x.Code == request.Code))
            {
                return new CreateUserTypeResponse();
            }

            UserType userType = new UserType
            {
                Code = request.Code,
                Name = request.Name,
                Description = request.Description,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            await db.AddAsync(userType);
            await db.SaveChangesAsync();

            return new CreateUserTypeResponse();
        }

        public Task<CreateUserStatusResponse> CreateUserStatusAsync(CreateUserStatusRequest request)
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