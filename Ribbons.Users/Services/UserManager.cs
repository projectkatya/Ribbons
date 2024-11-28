using Microsoft.Extensions.Logging;
using Ribbons.Data;
using Ribbons.Users.Data;
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

        public Task<UserType> CreateUserTypeAsync(string code, string name, string description = null)
        {
            throw new NotImplementedException();
        }

        public Task<UserAttributeType> CreateUserAttributeTypeAsync(string userType, string code, string name, string description = null)
        {
            throw new NotImplementedException();
        }

        public Task<UserCredentialType> CreateUserCredentialTypeAsync(string userType, string code, string name, string description = null)
        {
            throw new NotImplementedException();
        }

        public Task<UserTokenType> CreateUserTokenTypeAsync(string userType, string code, string name, string description = null)
        {
            throw new NotImplementedException();
        }

        public Task<UserStatus> CreateUserStatusAsync(string userType, string code, string name, string description = null)
        {
            throw new NotImplementedException();
        }
    }
}
