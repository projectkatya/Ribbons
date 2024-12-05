using Microsoft.EntityFrameworkCore;
using Ribbons.Data;
using Ribbons.Users.Data;
using Ribbons.Users.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ribbons.Users.Services
{
    public sealed class UserManager : IUserManager
    {
        private IRelationalDbManager<UserDb> DbManager { get; }

        public UserManager(IRelationalDbManager<UserDb> dbManager)
        {
            DbManager = dbManager;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }

        public async Task<CreateUserScopeResponse> CreateUserScopeAsync(UserScope userScope)
        {
            try
            {
                UserDb db = await DbManager.GetDatabaseAsync();

                userScope.TryValidateObject(out List<string> validationErrors);

                foreach (UserScopeAlias alias in userScope.Aliases)
                {
                    alias.TryValidateObject(out List<string> aliasValidationErrors);
                    validationErrors.AddRange(aliasValidationErrors);
                }

                if (validationErrors.Count > 0)
                {
                    return new CreateUserScopeResponse
                    {
                        Status = UserManagerStatus.Invalid,
                        Message = $"Request invalid"
                    };
                }

                if (await db.UserScopes.AnyAsync(x => x.Code == userScope.Code))
                {
                    return new CreateUserScopeResponse()
                    {
                        Status = UserManagerStatus.CodeInUse,
                        Message = $"Code {userScope.Code} is in use"
                    };
                }

                if (await db.UserScopes.AnyAsync(x => x.Name == userScope.Name))
                {
                    return new CreateUserScopeResponse
                    {
                        Status = UserManagerStatus.NameInUse,
                        Message = $"Name {userScope.Name} is in use"
                    };
                }

                return new CreateUserScopeResponse();
            }
            catch (Exception ex)
            {
                return new CreateUserScopeResponse();
            }
        }

        public Task<EditUserScopeResponse> EditUserScopeAsync(UserScope userScope)
        {
            throw new NotImplementedException();
        }
    }
}