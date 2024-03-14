using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Ribbons.Data;
using Ribbons.Users.Authentication.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Ribbons.Users.Authentication
{
    public abstract class UserAuthenticator<TUserType> : IUserAuthenticator<TUserType> where TUserType : Enum
    {
        protected ILogger Logger { get; }
        protected Dictionary<TUserType, IDatabaseManager> UserSources { get; }
        protected string CharacterSet { get; }
        protected TimeSpan SessionValidity { get; set; }

        protected UserAuthenticator(ILogger logger)
        {
            Logger = logger;
            UserSources = [];
            CharacterSet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            SessionValidity = TimeSpan.FromDays(90);
        }

        public async Task<LoginResponse> LoginAsync(TUserType userType, LoginRequest loginRequest, HttpResponse httpResponse)
        {
            try
            {
                if (!UserSources.TryGetValue(userType, out IDatabaseManager databaseManager))
                {
                    return LoginResponse.UserTypeInvalid();
                }

                Database database = await databaseManager.GetDatabaseAsync(loginRequest.Domain);

                if (database == null)
                {
                    return LoginResponse.DomainInvalid();
                }

                int userTypeId = userType.ConvertTo<int>();

                User user = await database.GetUser(userTypeId, loginRequest.UserIdentifier);

                if (user == null)
                {
                    return LoginResponse.UserNotFound();
                }

                UserPassword userPassword = user.UserPassword;

                if (userPassword == null)
                {
                    return LoginResponse.CredentialsInvalid();
                }

                if (!loginRequest.Password.VerifyPbkdf2(userPassword.PasswordSalt, userPassword.PasswordHash))
                {
                    return LoginResponse.CredentialsInvalid();
                }

                SessionCredentials sessionCredentials = CreateSessionCredentials();

                UserSession userSession = CreateSession(userType, user.UserId, sessionCredentials);

                await database.AddAsync(userSession);

                await database.SaveChangesAsync();

                SetSessionCookies(httpResponse, sessionCredentials, userSession);

                return LoginResponse.Ok();
            }
            catch (Exception ex)
            {
                Logger.LogError("{methodName} failed with exception {ex}", nameof(LoginAsync), ex);

                return LoginResponse.Error();
            }
        }

        public Task LogoutAsync(TUserType userType)
        {
            throw new NotImplementedException();
        }

        public Task RecoverPasswordAsync(TUserType userType)
        {
            throw new NotImplementedException();
        }

        public Task ResetPasswordAsync(TUserType userType)
        {
            throw new NotImplementedException();
        }

        private SessionCredentials CreateSessionCredentials()
        {
            return new SessionCredentials
            {
                SessionId = RandomNumberGenerator.GetString(CharacterSet, 128),
                SessionSecret = RandomNumberGenerator.GetString(CharacterSet, 128)
            };
        }

        private UserSession CreateSession(TUserType userType, long userId, SessionCredentials sessionCredentials)
        {
            DateTime createdDate = DateTime.Now;
            DateTime expiryDate = createdDate.Add(SessionValidity);

            sessionCredentials.SessionSecret.ComputePbkdf2(out byte[] sessionSecretSalt, out byte[] sessionSecretHash);

            return new UserSession
            {
                UserSessionId = $"{userType}:{userId}:{sessionCredentials.SessionId}".ComputeSHA512(),
                UserId = userId,
                CreatedDate = createdDate,
                ExpiryDate = expiryDate,
                SessionSecretSalt = sessionSecretSalt,
                SessionSecretHash = sessionSecretHash
            };
        }

        private void SetSessionCookies(HttpResponse httpResponse, SessionCredentials sessionCredentials, UserSession userSession)
        {

        }

        private SessionCredentials GetSessionCredentials(HttpRequest httpRequest)
        {
            return new SessionCredentials
            {

            };
        }
    }
}