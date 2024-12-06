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

                if (!userScope.TryValidateObject(out List<string> validationErrors))
                {
                    return new()
                    {
                        Status = UserManagerStatus.Invalid,
                        Message = $"Invalid request",
                        ValidationErrors = validationErrors
                    };
                }

                if (await db.UserScopes.AnyAsync(x => x.Code == userScope.Code))
                {
                    return new()
                    {
                        Status = UserManagerStatus.CodeInUse,
                        Message = $"Code {userScope.Code} is in use"
                    };
                }

                if (await db.UserScopes.AnyAsync(x => x.Name == userScope.Name))
                {
                    return new()
                    {
                        Status = UserManagerStatus.NameInUse,
                        Message = $"Name {userScope.Name} is in use"
                    };
                }

                TUserScope tUserScope = new()
                {
                    Code = userScope.Code,
                    Name = userScope.Name,
                    Description = userScope.Description,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                };

                await db.UserScopes.AddAsync(tUserScope);
                await db.SaveChangesAsync();

                CreateUserScopeResponse response = new()
                {
                    UserScopeId = tUserScope.UserScopeId,
                    Status = UserManagerStatus.Ok,
                    Message = $"Created scope {userScope.Code}",
                };

                response.Aliases = [];
                
                foreach (UserScopeAlias userScopeAlias in userScope.Aliases)
                {
                    userScopeAlias.Scope = tUserScope.Code; 
                    response.Aliases.Add(await CreateUserScopeAliasAsyncInternal(tUserScope.UserScopeId, userScopeAlias, db));
                }

                return response;
            }
            catch (Exception ex)
            {
                return new()
                {
                    Status = UserManagerStatus.Error,
                    Message = $"Failed to create scope {userScope.Code}"
                };
            }
        }

        public Task<EditUserScopeResponse> EditUserScopeAsync(UserScope userScope)
        {
            throw new NotImplementedException();
        }

		public async Task<CreateUserScopeAliasResponse> CreateUserScopeAliasAsync(UserScopeAlias userScopeAlias)
		{
			try
            {
                UserDb db = await DbManager.GetDatabaseAsync();

                TUserScope tUserScope = await db.UserScopes.FirstOrDefaultAsync(x => x.Code == userScopeAlias.Scope);

                if (tUserScope == null)
                {
                    return new()
                    {
                        Status = UserManagerStatus.NotFound,
                        Message = $"Unable to create alias for scope {userScopeAlias.Scope}. Scope doesn't exist"
                    };
                }

                return await CreateUserScopeAliasAsyncInternal(tUserScope.UserScopeId, userScopeAlias, db);
            }
            catch (Exception ex)
            {
                return new()
                {
                    Status = UserManagerStatus.Error,
                    Message = $"Failed to create user scope {userScopeAlias.Code}"
                };
            }
		}

        private async Task<CreateUserScopeAliasResponse> CreateUserScopeAliasAsyncInternal(long userScopeId, UserScopeAlias userScopeAlias, UserDb db)
        {
            try
            {
                if (!userScopeAlias.TryValidateObject(out List<string> validationErrors))
                {
                    return new()
                    {
                        Status = UserManagerStatus.Invalid,
                        Message = $"Invalid request",
                        ValidationErrors = validationErrors
                    };
                }

                if (await db.UserScopeAliases.AnyAsync(x => x.Code == userScopeAlias.Code))
                {
                    return new()
                    {
                        Status = UserManagerStatus.CodeInUse,
                        Message = $"Failed to create alias with code {userScopeAlias.Code} for scope {userScopeAlias.Scope}. Code {userScopeAlias.Code} is in use",
                    };
                }

                if (await db.UserScopeAliases.AnyAsync(x => x.Name == userScopeAlias.Name))
                {
                    return new()
                    {
                        Status = UserManagerStatus.NameInUse,
                        Message = $"Failed to create alias with name {userScopeAlias.Name} for scope {userScopeAlias.Scope}. Name {userScopeAlias.Name} is in use"
                    };
                }

                TUserScopeAlias tUserScopeAlias = new()
                {
                    UserScopeId = userScopeId,
                    Code = userScopeAlias.Code,
                    Name = userScopeAlias.Name,
                    Description = userScopeAlias.Description,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                };

                await db.UserScopeAliases.AddAsync(tUserScopeAlias);
                await db.SaveChangesAsync();

                return new()
                {
                    UserScopeAliasId = tUserScopeAlias.UserScopeAliasId,
                    Status = UserManagerStatus.Ok,
                    Message = $"Created alias {userScopeAlias.Code} for scope {userScopeAlias.Scope}"
                };
            }
            catch (Exception ex)
            {
                return new()
                {
                    Status = UserManagerStatus.Error,
                    Message = $"Failed to create alias {userScopeAlias.Code} for scope {userScopeAlias.Scope}"
                };
            }
        }
	}
}