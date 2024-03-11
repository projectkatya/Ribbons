using Microsoft.EntityFrameworkCore;
using Ribbons.Data;
using Ribbons.Users.Data;
using System.Threading.Tasks;

namespace Ribbons.Users
{
    internal static class DatabaseExtensions
    {
        public static async Task<bool> HasUsersWithUserName<TDatabase>(this TDatabase database, int userTypeId, string userName)
            where TDatabase : Database, IUserDatabase
        {
            return await database
                .Users
                .AsNoTracking()
                .AnyAsync(x => x.UserTypeId == userTypeId && x.UserName == userName);
        }

        public static async Task<bool> HasUsersWithEmailAddress<TDatabase>(this TDatabase database, int userTypeId, string emailAddress) 
            where TDatabase : Database, IUserDatabase
        {
            return await database
                .UserEmails
                .AsNoTracking()
                .AnyAsync(x => x.UserTypeId == userTypeId && x.EmailAddress == emailAddress);
        }

        public static async Task<bool> HasUsersWithPhoneNumber<TDatabase>(this TDatabase database, int userTypeId, string phoneNumber)
            where TDatabase : Database, IUserDatabase
        {
            return await database
                .UserPhones
                .AsNoTracking()
                .AnyAsync(x => x.UserTypeId == userTypeId && x.PhoneNumber == phoneNumber);
        }
    }
}