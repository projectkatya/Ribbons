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
        protected Dictionary<TUserType, CookieSettings> UserCookieSettings { get; }
        protected string CharacterSet { get; }
        protected TimeSpan SessionValidity { get; set; }

        protected UserAuthenticator(ILogger logger)
        {
            Logger = logger;
            UserSources = [];
            UserCookieSettings = [];
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

                SessionCredentials sessionCredentials = CreateSessionCredentials(loginRequest.Domain);

                UserSession userSession = CreateSession(userType, user.UserId, sessionCredentials);

                await database.AddAsync(userSession);

                await database.SaveChangesAsync();

                SetSessionCookies(userType, httpResponse, sessionCredentials, userSession);

                return LoginResponse.Ok();
            }
            catch (Exception ex)
            {
                Logger.LogError("{methodName} failed with exception {ex}", nameof(LoginAsync), ex);

                return LoginResponse.Error();
            }
        }

        public async Task LogoutAsync(TUserType userType, HttpRequest httpRequest, HttpResponse httpResponse)
        {
            try
            {
                SessionCredentials sessionCredentials = GetSessionCredentials(userType, httpRequest);

                if (!sessionCredentials.TryValidateObject(out _))
                {
                    return;
                }

                if (!UserSources.TryGetValue(userType, out IDatabaseManager databaseManager))
                {
                    return;
                }

                Database database = await databaseManager.GetDatabaseAsync(sessionCredentials.Domain);

                if (database == null)
                {
                    return;
                }

                byte[] sessionId = sessionCredentials.SessionId.ComputeSHA512();

                UserSession userSession = await database.FindAsync<UserSession>(sessionId);

                if (userSession.IsExpired)
                {
                    return;
                }

                if (userSession.IsLoggedOut)
                {
                    return;
                }

                userSession.IsLoggedOut = true;
                userSession.LogoutDate = DateTime.Now;

                await database.SaveChangesAsync();

                ClearSessionCookies(userType, sessionCredentials.Domain, httpResponse);
            }
            catch (Exception ex)
            {
                Logger.LogError("{methodName} failed with exception {ex}", nameof(LogoutAsync), ex);
            }
        }

        public Task RecoverPasswordAsync(TUserType userType)
        {
            throw new NotImplementedException();
        }

        public Task ResetPasswordAsync(TUserType userType)
        {
            throw new NotImplementedException();
        }

        private SessionCredentials CreateSessionCredentials(string domain)
        {
            return new SessionCredentials
            {
                Domain = domain,
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

        private void SetSessionCookies(TUserType userType, HttpResponse httpResponse, SessionCredentials sessionCredentials, UserSession userSession)
        {
            CookieSettings sessionCookie = UserCookieSettings[userType];

            CookieOptions options = new()
            {
                HttpOnly = true,
                Secure = true,
                Expires = userSession.ExpiryDate
            };

            string domainCookieName = sessionCookie.DomainCookieName;
            string sessionIdCookieName = sessionCookie.SessionIdCookieName(sessionCredentials.Domain);
            string sessionSecretCookieName = sessionCookie.SessionSecretCookieName(sessionCredentials.Domain);

            httpResponse.Cookies.Append(domainCookieName, sessionCredentials.Domain, options);
            httpResponse.Cookies.Append(sessionIdCookieName, sessionCredentials.SessionId, options);
            httpResponse.Cookies.Append(sessionSecretCookieName, sessionCredentials.SessionSecret, options);
        }

        private SessionCredentials GetSessionCredentials(TUserType userType, HttpRequest httpRequest)
        {
            CookieSettings sessionCookie = UserCookieSettings[userType];

            string domain = httpRequest.Cookies[sessionCookie.DomainCookieName];
            string sessionId = httpRequest.Cookies[sessionCookie.SessionIdCookieName(domain)];
            string sessionSecret = httpRequest.Cookies[sessionCookie.SessionSecretCookieName(domain)];

            return new SessionCredentials
            {
                Domain = domain,
                SessionId = sessionId,
                SessionSecret = sessionSecret
            };
        }

        private void ClearSessionCookies(TUserType userType, string domain, HttpResponse httpResponse)
        {
            CookieSettings sessionCookie = UserCookieSettings[userType];

            httpResponse.Cookies.Delete(sessionCookie.DomainCookieName);
            httpResponse.Cookies.Delete(sessionCookie.SessionIdCookieName(domain));
            httpResponse.Cookies.Delete(sessionCookie.SessionSecretCookieName(domain));
        }
    }
}