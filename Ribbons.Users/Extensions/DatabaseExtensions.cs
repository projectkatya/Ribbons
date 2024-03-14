using Microsoft.EntityFrameworkCore;
using Ribbons.Data;
using System.Threading.Tasks;

namespace Ribbons.Users
{
    internal static class DatabaseExtensions
    {
        public static async Task<User> GetUser(this Database database, int userTypeId, string userIdentifier)
        {
            return await database
                .Set<User>()
                .Include(x => x.UserPassword)
                .FirstOrDefaultAsync(x =>
                    x.UserTypeId == userTypeId &&
                    (
                        x.UserName == userIdentifier ||
                        x.UserEmail.EmailAddress == userIdentifier ||
                        x.UserPhone.PhoneNumber == userIdentifier
                    ));
        }

        public static async Task<bool> HasUsersWithUserName(this Database database, int userTypeId, string userName)
        {
            return await database
                .Set<User>()
                .AsNoTracking()
                .AnyAsync(x => x.UserTypeId == userTypeId && x.UserName == userName);
        }

        public static async Task<bool> HasUsersWithEmailAddress(this Database database, int userTypeId, string emailAddress)
        {
            return await database
                .Set<UserEmail>()
                .AsNoTracking()
                .AnyAsync(x => x.UserTypeId == userTypeId && x.EmailAddress == emailAddress);
        }

        public static async Task<bool> HasUsersWithPhoneNumber(this Database database, int userTypeId, string phoneNumber)
        {
            return await database
                .Set<UserPhone>()
                .AsNoTracking()
                .AnyAsync(x => x.UserTypeId == userTypeId && x.PhoneNumber == phoneNumber);
        }
    }
}