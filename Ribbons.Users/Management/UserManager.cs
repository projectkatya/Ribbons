using Microsoft.Extensions.Logging;
using Ribbons.Data;
using Ribbons.Users.Management.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ribbons.Users.Management
{
    public abstract class UserManager<TUserType> : IUserManager<TUserType> where TUserType : Enum
    {
        protected ILogger Logger { get; }
        protected Dictionary<TUserType, IDatabaseManager> UserSources { get; }

        protected UserManager(ILogger logger)
        {
            Logger = logger;
            UserSources = [];
        }

        public async Task<CreateUserResponse> CreateUserAsync(TUserType userType, CreateUserRequest request)
        {
            try
            {
                int userTypeId = userType.ConvertTo<int>();

                if (!UserSources.TryGetValue(userType, out IDatabaseManager databaseManager))
                {
                    Logger.LogError("Unable to create user of type {type}. User type is not supported", userType);
                    
                    return new CreateUserResponse()
                    {
                        Status = CreateUserStatus.UserTypeInvalid
                    };
                }
                
                Database database = await databaseManager.GetDatabaseAsync(request.Domain);

                if (database == null)
                {
                    Logger.LogError("Unable to create user of type {type}. Could not find an appropriate source.", userType);
                    
                    return new CreateUserResponse
                    {
                        Status = CreateUserStatus.DomainInvalid
                    };
                }

                if (await database.HasUsersWithUserName(userTypeId, request.UserName))
                {
                    Logger.LogError("Unable to create user of type {type} with username {userName}. Username is in use by another account.", userType, request.UserName);

                    return new CreateUserResponse
                    {
                        Status = CreateUserStatus.UserNameTaken
                    };
                }

                if (await database.HasUsersWithEmailAddress(userTypeId, request.EmailAddress))
                {
                    Logger.LogError("Unable to create user of type {type} with email address {emailAddress}. Email address is in use by another account.", userType, request.EmailAddress);

                    return new CreateUserResponse
                    {
                        Status = CreateUserStatus.EmailAddressTaken
                    };
                }

                if (await database.HasUsersWithPhoneNumber(userTypeId, request.PhoneNumber))
                {
                    Logger.LogError("Unable to create user of type {type} with phone number {phoneNumber}. Phone number is in use by another account.", userType, request.PhoneNumber);

                    return new CreateUserResponse
                    {
                        Status = CreateUserStatus.PhoneNumberTaken
                    };
                }

                DateTime now = DateTime.Now;

                request.Password.ComputePbkdf2(out byte[] passwordSalt, out byte[] passwordHash);

                User user = new()
                {
                    UserTypeId = userTypeId,
                    Status = UserStatus.Active,
                    CreatedDate = now,
                    ModifiedDate = now,
                    UserName = request.UserName,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    UserEmail = new UserEmail
                    {
                        UserTypeId = userTypeId,
                        CreatedDate = now,
                        ModifiedDate = now,
                        EmailAddress = request.EmailAddress
                    },
                    UserPhone = string.IsNullOrWhiteSpace(request.PhoneNumber) ? null : new UserPhone
                    {
                        UserTypeId = userTypeId,
                        CreatedDate = now,
                        ModifiedDate = now,
                        PhoneNumber = request.PhoneNumber
                    },
                    UserPassword = new UserPassword
                    {
                        CreatedDate = now,
                        ModifiedDate = now,
                        PasswordSalt = passwordSalt,
                        PasswordHash = passwordHash
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