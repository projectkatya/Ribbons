using Microsoft.EntityFrameworkCore;
using Ribbons.Data;
using Ribbons.Users.Data;
using Ribbons.Users.Services.Models;
using System;
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

        public async Task CreateUserTypeAsync(UserType userType)
        {
            UserDb db = await DbManager.GetDatabaseAsync();

            if (await db.UserTypes.AnyAsync(x => x.Code == userType.Code))
            {
                return;
            }

            if (await db.UserTypes.AnyAsync(x => x.Name == userType.Name))
            {
                return;
            }

            DateTime now = DateTime.Now;

            TUserType tUserType = new()
            {
                Code = userType.Code,
                Name = userType.Name,
                Description = userType.Description,
                CreatedDate = now,
                ModifiedDate = now
            };

            await db.UserTypes.AddAsync(tUserType);
            await db.SaveChangesAsync();
        }

        public async Task CreateUserAttributeTypeAsync(UserAttributeType userAttributeType)
        {
            UserDb db = await DbManager.GetDatabaseAsync();

            TUserType tUserType = await db.UserTypes.FirstOrDefaultAsync(x => x.Code == userAttributeType.UserType);

            if (tUserType == null)
            {
                return;
            }

            if (await db.UserAttributeTypes.AnyAsync(x => x.UserTypeId == tUserType.UserTypeId && x.Code == userAttributeType.Code))
            {
                return;
            }

            if (await db.UserAttributeTypes.AnyAsync(x => x.UserTypeId == tUserType.UserTypeId && x.Name == userAttributeType.Name))
            {
                return;
            }

            TUserAttributeType tUserAttributeType = new()
            {
                UserTypeId = tUserType.UserTypeId,
                Code = userAttributeType.Code,
                Name = userAttributeType.Name,
                Description = userAttributeType.Description,
                ValueType = userAttributeType.ValueType
            };

            await db.UserAttributeTypes.AddAsync(tUserAttributeType);
            await db.SaveChangesAsync();
        }
    }
}