using Microsoft.EntityFrameworkCore;
using Ribbons.Data;

namespace Ribbons.Users.Data
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder SetupUserModel(this ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasOneToOne<User, UserEmail>(x => x.UserEmail, x => x.User, x => x.UserId)
                .HasOneToOne<User, UserPassword>(x => x.UserPassword, x => x.User, x => x.UserId)
                .HasOneToOne<User, UserPhone>(x => x.UserPhone, x => x.User, x => x.UserId)
                .HasOneToMany<User, UserSession>(x => x.UserSessions, x => x.User, x => x.UserId)
                .HasOneToMany<User, UserToken>(x => x.UserTokens, x => x.User, x => x.UserId)
                .HasOneToMany<UserType, User>(x => x.Users, x => x.UserType, x => x.UserTypeId)
                .HasOneToMany<UserType, UserEmail>(x => x.UserEmails, x => x.UserType, x => x.UserTypeId)
                .HasOneToMany<UserType, UserPhone>(x => x.UserPhones, x => x.UserType, x => x.UserTypeId);

            return modelBuilder;
        }
    }
}