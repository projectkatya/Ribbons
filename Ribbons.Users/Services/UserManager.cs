using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ribbons.Data;
using Ribbons.Users.Data;
using Ribbons.Users.Definitions;
using System;
using System.Threading.Tasks;

namespace Ribbons.Users.Services
{
    public sealed class UserManager : IUserManager
    {
        private ILogger Logger { get; }
        private IRelationalDbManager<UserDb> DbManager { get; }

        public UserManager(ILogger<UserManager> logger, IRelationalDbManager<UserDb> dbManager)
        {
            Logger = logger;
            DbManager = dbManager;
        }

        public async Task<UserType> CreateUserTypeAsync(string code, string name, string description = null)
        {
            UserDb db = await DbManager.GetDatabaseAsync();

            if (await db.UserTypes.AnyAsync(x => x.Code == code))
            {
                throw new UserManagerException($"Code {code} in use")
                {
                    Operation = UserManagerOperation.CreateUserType,
                    ErrorCode = UserManagerErrorCode.CodeInUse
                };
            }

            if (await db.UserTypes.AnyAsync(x => x.Name == name))
            {
                throw new UserManagerException($"Name {name} in use")
                {
                    Operation = UserManagerOperation.CreateUserType,
                    ErrorCode = UserManagerErrorCode.NameInUse
                };
            }

            UserType userType = new()
            {
                Code = code,
                Name = name,
                Description = description,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            await db.UserTypes.AddAsync(userType);
            await db.SaveChangesAsync();

            return userType;
        }

        public async Task<UserAttributeType> CreateUserAttributeTypeAsync(string userTypeCode, string code, string name, UserAttributeValueType valueType, string description = null)
        {
            UserDb db = await DbManager.GetDatabaseAsync();

            UserType userType = await db.UserTypes.FirstOrDefaultAsync(x => x.Code == userTypeCode);

            if (userType == null)
            {
                throw new UserManagerException($"Invalid user type {userTypeCode}")
                {
                    Operation = UserManagerOperation.CreateUserAttributeType,
                    ErrorCode = UserManagerErrorCode.InvalidUserType
                };
            }

            if (await db.UserAttributeTypes.AnyAsync(x => x.UserTypeId == userType.UserTypeId && x.Code == code))
            {
                throw new UserManagerException($"Code {code} is in use")
                {
                    Operation = UserManagerOperation.CreateUserAttributeType,
                    ErrorCode = UserManagerErrorCode.CodeInUse
                };
            }

            if (await db.UserAttributeTypes.AnyAsync(x => x.UserTypeId == userType.UserTypeId && x.Name == name))
            {
                throw new UserManagerException($"Name {name} is in use")
                {
                    Operation = UserManagerOperation.CreateUserAttributeType,
                    ErrorCode = UserManagerErrorCode.NameInUse
                };
            }

            UserAttributeType userAttributeType = new()
            {
                UserTypeId = userType.UserTypeId,
                Code = code,
                Name = name,
                Description = description,
                ValueType = valueType,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            await db.UserAttributeTypes.AddAsync(userAttributeType);
            await db.SaveChangesAsync();

            return userAttributeType;
        }

        public async Task<UserCredentialType> CreateUserCredentialTypeAsync(string userTypeCode, string code, string name, string description = null)
        {
            UserDb db = await DbManager.GetDatabaseAsync();

            UserType userType = await db.UserTypes.FirstOrDefaultAsync(x => x.Code == userTypeCode);

            if (userType == null)
            {
                throw new UserManagerException($"Invalid user type {userTypeCode}")
                {
                    Operation = UserManagerOperation.CreateUserCredentialType,
                    ErrorCode = UserManagerErrorCode.InvalidUserType
                };
            }

            if (await db.UserCredentialTypes.AnyAsync(x => x.UserTypeId == userType.UserTypeId && x.Code == code))
            {
                throw new UserManagerException($"Code {code} in use for user type {userTypeCode}")
                {
                    Operation = UserManagerOperation.CreateUserCredentialType,
                    ErrorCode = UserManagerErrorCode.CodeInUse
                };
            }

            if (await db.UserCredentialTypes.AnyAsync(x => x.UserTypeId == userType.UserTypeId && x.Name == name))
            {
                throw new UserManagerException($"Name {name} in use for user type {userTypeCode}")
                {
                    Operation = UserManagerOperation.CreateUserCredentialType,
                    ErrorCode = UserManagerErrorCode.NameInUse
                };
            }

            UserCredentialType userCredentialType = new()
            {
                UserTypeId = userType.UserTypeId,
                Code = code,
                Name = name,
                Description = description,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            return userCredentialType;
        }

        public async Task<UserTokenType> CreateUserTokenTypeAsync(string userTypeCode, string code, string name, string description = null)
        {
            UserDb db = await DbManager.GetDatabaseAsync();

            UserType userType = await db.UserTypes.FirstOrDefaultAsync(x => x.Code == userTypeCode);

            UserTokenType tokenType = new();

            return tokenType;
        }

        public Task<UserStatus> CreateUserStatusAsync(string userType, string code, string name, string description = null)
        {
            throw new NotImplementedException();
        }
    }
}
