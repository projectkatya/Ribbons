using Microsoft.EntityFrameworkCore;
using Ribbons.Data;

namespace Ribbons.Users.Data
{
    public abstract class UserDb : RelationalDb
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserEmail> UserEmails { get; set; }
        public DbSet<UserPhone> UserPhones { get; set; }
        public DbSet<UserSession> UserSessions { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }

        protected UserDb(RelationalDbProvider provider) : base(provider) { }
    }
}