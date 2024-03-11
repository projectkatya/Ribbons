using Microsoft.Extensions.Logging;
using Ribbons.Data;
using Ribbons.Users.Data;
using Ribbons.Users.Management.Models;
using System;
using System.Threading.Tasks;

namespace Ribbons.Users.Management
{
    public abstract class UserManager<TDatabase> : IUserManager where TDatabase : Database, IUserDatabase
    {
        protected int UserTypeId { get; }
        protected ILogger Logger { get; }
        protected IDatabaseManager<TDatabase> DatabaseManager { get; set; }

        protected UserManager(int userTypeId, ILogger logger, IDatabaseManager<TDatabase> databaseManager)
        {
            UserTypeId = userTypeId;
            Logger = logger;
            DatabaseManager = databaseManager;
        }

        public async Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request)
        {
            try
            {
                TDatabase database = await DatabaseManager.GetDatabaseAsync(request.Domain);

                if (database == null)
                {
                    return new CreateUserResponse
                    {
                        Status = CreateUserStatus.DomainInvalid
                    };
                }

                if (await database.HasUsersWithUserName(UserTypeId, request.UserName))
                {
                    return new CreateUserResponse
                    {
                        Status = CreateUserStatus.UserNameTaken
                    };
                }

                if (await database.HasUsersWithEmailAddress(UserTypeId, request.EmailAddress))
                {
                    return new CreateUserResponse
                    {
                        Status = CreateUserStatus.EmailAddressTaken
                    };
                }

                if (await database.HasUsersWithPhoneNumber(UserTypeId, request.PhoneNumber))
                {
                    return new CreateUserResponse
                    {
                        Status = CreateUserStatus.PhoneNumberTaken
                    };
                }

                DateTime now = DateTime.Now;

                User user = new()
                {
                    UserTypeId = UserTypeId,
                    Status = UserStatus.Active,
                    CreatedDate = now,
                    ModifiedDate = now,
                    UserName = request.UserName,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    UserEmail = new UserEmail
                    {
                        UserTypeId = UserTypeId,
                        CreatedDate = now,
                        ModifiedDate = now,
                        EmailAddress = request.EmailAddress
                    },
                    UserPhone = string.IsNullOrWhiteSpace(request.PhoneNumber) ? null : new UserPhone
                    {
                        UserTypeId = UserTypeId,
                        CreatedDate = now,
                        ModifiedDate = now,
                        PhoneNumber = request.PhoneNumber
                    }
                };

                await database.AddAsync(user);
                await database.SaveChangesAsync();

                return new CreateUserResponse
                {
                    Status = CreateUserStatus.Ok
                };
            }
            catch (Exception ex)
            {
                Logger.LogError("{methodName} failed with exception {ex}", nameof(CreateUserAsync), ex);

                return new CreateUserResponse
                {
                    Status = CreateUserStatus.Error
                };
            }
        }
    }
}