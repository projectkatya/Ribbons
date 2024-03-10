using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ribbons.Data;
using Ribbons.Users.Authentication.Models;
using Ribbons.Users.Data;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ribbons.Users.Authentication
{
    public abstract class UserAuthenticator<TDatabase> : IUserAuthenticator where TDatabase : Database, IUserDatabase
    {
        protected ILogger Logger { get; }
        protected IDatabaseManager<TDatabase> DatabaseManager { get; }
        protected int UserTypeId { get; set; }
        protected string DomainCookie { get; set; }
        protected string SessionIdCookieTemplate { get; set; }
        protected string SessionSecretCookieTemplate { get; set; }
        protected int SessionIdLength { get; set; } = 128;
        protected int SessionSecretLength { get; set; } = 128;
        protected HttpRequest Request { get; set; }
        protected HttpResponse Response { get; set; }

        protected UserAuthenticator(int userTypeId, ILogger logger, IDatabaseManager<TDatabase> databaseManager)
        {
            UserTypeId = userTypeId;
            Logger = logger;
            DatabaseManager = databaseManager;
        }

        public IUserAuthenticator SetHttpContext(HttpRequest httpRequest, HttpResponse httpResponse)
        {
            Request = httpRequest;
            Response = httpResponse;

            return this;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest)
        {
            try
            {
                TDatabase database = await DatabaseManager.GetDatabaseAsync(loginRequest.Domain);

                if (database == null)
                {
                    return new LoginResponse()
                    {
                        Status = LoginStatus.DomainInvalid
                    };
                }


                User user = await database.Users.FirstOrDefaultAsync(ActiveUserPredicate(loginRequest.UserIdentifier));

                if (user == null)
                {
                    return new LoginResponse
                    {
                        Status = LoginStatus.UserNotFound
                    };
                }



                return new LoginResponse
                {
                    Status = LoginStatus.Ok
                };
            }
            catch (Exception ex)
            {
                Logger.LogError("{methodName} failed with exception {ex}", nameof(LoginAsync), ex);

                return new LoginResponse
                {
                    Status = LoginStatus.Error
                };
            }
        }

        public Task LogoutAsync()
        {
            throw new NotImplementedException();
        }

        public Task RecoverPasswordAsync()
        {
            throw new NotImplementedException();
        }

        public Task ResetPasswordAsync()
        {
            throw new NotImplementedException();
        }

        private Expression<Func<User, bool>> ActiveUserPredicate(string identifier)
        {
            return x =>
                x.UserTypeId == UserTypeId &&
                x.Status != UserStatus.Deleted &&
                (x.UserName == identifier || x.UserEmail.EmailAddress == identifier || x.UserPhone.PhoneNumber == identifier);
        }
    }
}