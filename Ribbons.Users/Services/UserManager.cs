using Microsoft.EntityFrameworkCore;
using Ribbons.Data;
using Ribbons.Users.Data;
using Ribbons.Users.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ribbons.Users.Services;

public sealed class UserManager : IUserManager
{
    UserDb Db { get; }

    public UserManager(IRelationalDbManager<UserDb> dbManager)
    {
        Db = dbManager.GetDatabase();
    }

    public async Task<CreateUserScopeResponse> CreateUserScopeAsync(UserScope userScope)
    {
        try
        {
            if (!userScope.TryValidateObject(out List<string> validationErrors))
            {
                return new()
                {
                    Status = UserManagerStatus.Invalid,
                    Message = $"Invalid request",
                    ValidationErrors = validationErrors
                };
            }

            if (await Db.UserScopes.AnyAsync(x => x.Code == userScope.Code))
            {
                return new()
                {
                    Status = UserManagerStatus.CodeInUse,
                    Message = $"Code {userScope.Code} is in use"
                };
            }

            if (await Db.UserScopes.AnyAsync(x => x.Name == userScope.Name))
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

            await Db.UserScopes.AddAsync(tUserScope);
            await Db.SaveChangesAsync();

            return new()
            {
                UserScopeId = tUserScope.UserScopeId,
                Status = UserManagerStatus.Ok,
                Message = $"Created scope {userScope.Code}",
            };
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

    public async Task<EditUserScopeResponse> EditUserScopeAsync(UserScope userScope)
    {
        try
        {
            if (!userScope.TryValidateObject(out List<string> validationErrors))
            {
                return new()
                {
                    Status = UserManagerStatus.Invalid,
                    ValidationErrors = validationErrors
                };
            }

            TUserScope tUserScope = await Db.UserScopes.FirstOrDefaultAsync(x => x.Code == userScope.Code);

            if (tUserScope == null)
            {
                return new()
                {
                    Status = UserManagerStatus.NotFound
                };
            }

            tUserScope.Name = userScope.Name;
            tUserScope.Description = userScope.Description;
            tUserScope.ModifiedDate = DateTime.Now;

            await Db.SaveChangesAsync();

            return new()
            {
                Status = UserManagerStatus.Ok
            };
        }
        catch (Exception ex)
        {
            return new()
            {
                Status = UserManagerStatus.Error
            };
        }
    }

    public async Task<CreateUserScopeAliasResponse> CreateUserScopeAliasAsync(UserScopeAlias userScopeAlias)
    {
        try
        {
            TUserScope tUserScope = await Db.UserScopes.FirstOrDefaultAsync(x => x.Code == userScopeAlias.Scope);

            if (tUserScope == null)
            {
                return new()
                {
                    Status = UserManagerStatus.NotFound,
                    Message = $"Unable to create alias for scope {userScopeAlias.Scope}. Scope doesn't exist"
                };
            }

            if (!userScopeAlias.TryValidateObject(out List<string> validationErrors))
            {
                return new()
                {
                    Status = UserManagerStatus.Invalid,
                    Message = $"Invalid request",
                    ValidationErrors = validationErrors
                };
            }

            if (await Db.UserScopeAliases.AnyAsync(x => x.Code == userScopeAlias.Code))
            {
                return new()
                {
                    Status = UserManagerStatus.CodeInUse,
                    Message = $"Failed to create alias with code {userScopeAlias.Code} for scope {userScopeAlias.Scope}. Code {userScopeAlias.Code} is in use",
                };
            }

            if (await Db.UserScopeAliases.AnyAsync(x => x.Name == userScopeAlias.Name))
            {
                return new()
                {
                    Status = UserManagerStatus.NameInUse,
                    Message = $"Failed to create alias with name {userScopeAlias.Name} for scope {userScopeAlias.Scope}. Name {userScopeAlias.Name} is in use"
                };
            }

            TUserScopeAlias tUserScopeAlias = new()
            {
                UserScopeId = tUserScope.UserScopeId,
                Code = userScopeAlias.Code,
                Name = userScopeAlias.Name,
                Description = userScopeAlias.Description,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            await Db.UserScopeAliases.AddAsync(tUserScopeAlias);
            await Db.SaveChangesAsync();

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

    public async Task<EditUserScopeAliasResponse> EditUserScopeAliasAsync(UserScopeAlias userScopeAlias)
    {
        try
        {
            TUserScope tUserScope = await Db.UserScopes.FirstOrDefaultAsync(x => x.Code == userScopeAlias.Code);

            if (tUserScope == null)
            {
                return new()
                {
                    Status = UserManagerStatus.NotFound
                };
            }

            TUserScopeAlias tUserScopeAlias = await Db.UserScopeAliases.FirstOrDefaultAsync(x => x.Code == userScopeAlias.Code);

            if (userScopeAlias == null)
            {
                return new()
                {
                    Status = UserManagerStatus.NotFound
                };
            }

            tUserScopeAlias.Name = userScopeAlias.Name;
            tUserScopeAlias.Description = userScopeAlias.Description;
            tUserScopeAlias.ModifiedDate = DateTime.Now;

            await Db.SaveChangesAsync();

            return new()
            {
                Status = UserManagerStatus.Ok
            };
        }
        catch (Exception ex)
        {
            return new()
            {
                Status = UserManagerStatus.Error
            };
        }
    }

    public async Task<CreateUserTypeResponse> CreateUserTypeAsync(UserType userType)
    {
        try
        {
            if (!userType.TryValidateObject(out List<string> validationErrors))
            {
                return new()
                {
                    Status = UserManagerStatus.Invalid,
                    ValidationErrors = validationErrors
                };
            }

            TUserScope tUserScope = await Db.UserScopes.FirstOrDefaultAsync(x => x.Code == userType.Scope);

            if (tUserScope == null)
            {
                return new()
                {
                    Status = UserManagerStatus.NotFound
                };
            }

            if (await Db.UserTypes.AnyAsync(x => x.Code == userType.Code))
            {
                return new()
                {
                    Status = UserManagerStatus.CodeInUse
                };
            }

            if (await Db.UserTypes.AnyAsync(x => x.Name == userType.Name))
            {
                return new()
                {
                    Status = UserManagerStatus.NameInUse
                };
            }

            TUserType tUserType = new()
            {
                UserScopeId = tUserScope.UserScopeId,
                Code = userType.Code,
                Name = userType.Name,
                Description = userType.Description,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
            };

            await Db.UserTypes.AddAsync(tUserType);
            await Db.SaveChangesAsync();

            return new()
            {
                Status = UserManagerStatus.Ok
            };
        }
        catch (Exception ex)
        {
            return new()
            {
                Status = UserManagerStatus.Error
            };
        }
    }

    public async Task<EditUserTypeResponse> EditUserTypeAsync(UserType userType)
    {
        try
        {
            if (!userType.TryValidateObject(out List<string> validationErrors))
            {
                return new()
                {
                    Status = UserManagerStatus.Invalid
                };
            }

            TUserScope tUserScope = await Db.UserScopes.FirstOrDefaultAsync(x => x.Code == userType.Scope);

            if (tUserScope == null)
            {
                return new()
                {
                    Status = UserManagerStatus.NotFound
                };
            }

            return new();
        }
        catch (Exception ex)
        {
            return new();
        }
    }
}