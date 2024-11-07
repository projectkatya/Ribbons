using Microsoft.EntityFrameworkCore;
using Ribbons.Data;
using Ribbons.Data.Extensions;

namespace Ribbons.Users.Data
{
    public abstract class UserDb : RelationalDb
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserEmail> UserEmails { get; set; }
        public DbSet<UserPhone> UserPhones { get; set; }
        public DbSet<UserSession> UserSessions { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }
        public DbSet<UserTokenType> UserTokenTypes { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

        protected UserDb(RelationalDbProvider provider) : base(provider) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasOneToOne<User, UserEmail>(x => x.UserEmail, x => x.User, x => x.UserId)
                .HasOneToOne<User, UserPhone>(x => x.UserPhone, x => x.User, x => x.UserId)
                .HasOneToMany<User, UserSession>(x => x.UserSessions, x => x.User, x => x.UserId)
                .HasOneToMany<User, UserToken>(x => x.UserTokens, x => x.User, x => x.UserId)
                .HasOneToMany<UserTokenType, UserToken>(x => x.UserTokens, x => x.UserTokenType, x => x.UserTokenTypeId)
                .HasOneToMany<UserType, User>(x => x.Users, x => x.UserType, x => x.UserTypeId);

            modelBuilder.Entity<User>().HasOne(x => x.UserEmail).WithOne(x => x.User);
        }
    }
}