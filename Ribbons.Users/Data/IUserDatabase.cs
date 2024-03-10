using Microsoft.EntityFrameworkCore;

namespace Ribbons.Users.Data
{
    public interface IUserDatabase
    {
        DbSet<User> Users { get; set; }
        DbSet<UserEmail> UserEmails { get; set; }
        DbSet<UserPassword> UserPasswords { get; set; }
        DbSet<UserPhone> UserPhones { get; set; }
        DbSet<UserSession> UserSessions { get; set; }
        DbSet<UserToken> UserTokens { get; set; }
        DbSet<UserType> UserTypes { get; set; }
    }
}