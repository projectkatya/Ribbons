using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ribbons.Data;
using Ribbons.Users.Data;
using Ribbons.Users.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ribbons.Users.Services
{
    public class UserManager : IUserManager
    {
        protected IRelationalDbManager<UserDb> UserDbManager { get; }
        protected ILogger Logger { get; }

        public UserManager(ILogger<UserManager> logger, IRelationalDbManager<UserDb> userDbManager)
        {
            Logger = logger;
            UserDbManager = userDbManager;
        }

        public async Task<CreateUserTypeResponse> CreateUserTypeAsync(CreateUserTypeRequest request)
        {
            try
            {
                UserDb db = await UserDbManager.GetDatabaseAsync();

                if (!request.TryValidateObject(out List<string> validationErrors))
                {
                    return new()
                    {
                        Status = CreateUserTypeResponseCode.InvalidRequest,
                        Message = "Failed to create user type. Request is invalid",
                        ValidationErrors = validationErrors
                    };
                }

                if (await db.UserTypes.AnyAsync(x => x.Code == request.Code))
                {
                    return new()
                    {
                        Status = CreateUserTypeResponseCode.CodeInUse,
                        Message = $"Failed to create user type. Code {request.Code} is in use" 
                    };
                }

                if (await db.UserTypes.AnyAsync(x=> x.Name == request.Name))
                {
                    return new()
                    {
                        Status = CreateUserTypeResponseCode.NameInUse,
                        Message = $"Failed to create user type. Name {request.Name} is in use"
                    };
                }

                UserType userType = new()
                {
                    Code = request.Code,
                    Name = request.Name,
                    Description = request.Description,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                };

                await db.AddAsync(userType);
                
                await db.SaveChangesAsync();

                return new()
                {
                    UserTypeId = userType.UserTypeId,
                    Status = CreateUserTypeResponseCode.Ok,
                    Message = $"User type {request.Name} with code {request.Code} created"
                };
            }
            catch (Exception ex)
            {
                Logger?.LogError("Failed to create user type {name} with code {code}. Exception {ex}", request.Name, request.Code, ex);
                
                return new()
                {
                    Status = CreateUserTypeResponseCode.Error,
                    Message = $"Failed to create user type {request.Name} with code {request.Code}"
                };
            }
        }

        public async Task<CreateUserStatusResponse> CreateUserStatusAsync(CreateUserStatusRequest request)
        {
            try
            {
                UserDb db = await UserDbManager.GetDatabaseAsync();

                if (!request.TryValidateObject(out List<string> validationErrors))
                {
                    return new()
                    {
                        Status = CreateUserStatusResponseCode.InvalidRequest,
                        Message = "Failed to create user status. Request is invalid",
                        ValidationErrors = validationErrors
                    };
                }

                if (await db.UserStatuses.AnyAsync(x => x.Code == request.Code))
                {
                    return new()
                    {
                        Status = CreateUserStatusResponseCode.CodeInUse,
                        Message = $"Failed to create user status for user type {request.UserType}. Code {request.Code} is in use"
                    };
                }

                if (await db.UserStatuses.AnyAsync(x => x.Name == request.Name))
                {
                    return new()
                    {
                        Status = CreateUserStatusResponseCode.NameInUse,
                        Message = $"Failed to create user status for user type {request.UserType}. Name {request.Name} is in use"
                    };
                }

                UserType userType = await db.UserTypes.FirstOrDefaultAsync(x => x.Code == request.UserType);

                if (userType == null)
                {
                    return new()
                    {
                        Status = CreateUserStatusResponseCode.UserTypeNotFound,
                        Message = $"Failed to create user status for user type {request.UserType}. User type {request.UserType} does not exist"
                    };
                }

                UserStatus userStatus = new()
                {
                    UserTypeId = userType.UserTypeId,
                    Code = request.Code,
                    Name = request.Name,
                    Description = request.Description,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                };

                await db.AddAsync(userStatus);
                
                await db.SaveChangesAsync();

                return new()
                {
                    UserStatusId = userStatus.UserStatusId,
                    Status = CreateUserStatusResponseCode.Ok,
                    Message = $"Created user status {request.Name} with code {request.Code} for user type {request.UserType}"
                };
            }
            catch (Exception ex)
            {
                Logger?.LogError("Failed to create user status {name} with code {code}. Exception {ex}", request.Name, request.Code, ex);

                return new()
                {
                    Status = CreateUserStatusResponseCode.Error,
                    Message = $"Failed to create user status {request.Name} with code {request.Code}"
                };
            }
        }

        public async Task<CreateUserTokenTypeResponse> CreateUserTokenTypeAsync(CreateUserTokenTypeRequest request)
        {
            try
            {
                UserDb db = await UserDbManager.GetDatabaseAsync();

                if (!request.TryValidateObject(out List<string> validationErrors))
                {
                    return new()
                    {
                        Status = CreateUserTokenTypeResponseCode.InvalidRequest,
                        Message = $"Failed to create user token type. Request is invalid",
                        ValidationErrors = validationErrors
                    };
                }

                if (!await db.UserTokenTypes.AnyAsync(x => x.Code == request.Code))
                {
                    return new()
                    {
                        Status = CreateUserTokenTypeResponseCode.CodeInUse,
                        Message = $"Failed to create user token type for user type {request.UserType}. Code {request.Code} is in use"
                    };
                }

                if (!await db.UserTokenTypes.AnyAsync(x => x.Name == request.Name))
                {
                    return new()
                    {
                        Status = CreateUserTokenTypeResponseCode.NameInUse,
                        Message = $"Failed to create user token type for user type {request.UserType}. Name {request.Name} is in use"
                    };
                }

                UserType userType = await db.UserTypes.FirstOrDefaultAsync(x => x.Code == request.UserType);

                if (userType == null)
                {
                    return new()
                    {
                        Status = CreateUserTokenTypeResponseCode.UserTypeNotFound,
                        Message = $"Failed to create user token type for user type {request.UserType}. User type {request.UserType} does not exist"
                    };
                }

                UserTokenType userTokenType = new()
                {
                    UserTypeId = userType.UserTypeId,
                    Code = request.Code,
                    Name = request.Name,
                    Description = request.Description,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                };

                await db.AddAsync(userTokenType);
                await db.SaveChangesAsync();

                return new()
                {
                    UserTokenTypeId = userTokenType.UserTokenTypeId,
                    Status = CreateUserTokenTypeResponseCode.Ok,
                    Message = $"Created user token type {request.Name} with code {request.Code} for user type {request.UserType}"
                };
            }
            catch (Exception ex)
            {
                return new()
                {
                    Status = CreateUserTokenTypeResponseCode.Error
                };
            }
        }

        public Task<CreateUserGroupResponse> CreateUserGroupAsync(CreateUserGroupRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request)
        {
            UserDb db = await UserDbManager.GetDatabaseAsync();

            User user = new User
            {

            };

            return new CreateUserResponse();
        }
    }
}