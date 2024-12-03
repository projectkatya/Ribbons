using Microsoft.EntityFrameworkCore;
using Ribbons.Data;
using Ribbons.Data.Extensions;

namespace Ribbons.Users.Data
{
    public abstract class UserDb : RelationalDb
    {
        public DbSet<TUser> Users { get; set; }
        public DbSet<TUserAttribute> UserAttributes { get; set; }
        public DbSet<TUserAttributeType> UserAttributeTypes { get; set; }
        public DbSet<TUserCredential> UserCredentials { get; set; }
        public DbSet<TUserCredentialType> UserCredentialTypes { get; set; }
        public DbSet<TUserEmail> UserEmails { get; set; }
        public DbSet<TUserGroup> UserGroups { get; set; }
        public DbSet<TUserGroupUser> UserGroupUsers { get; set; }
        public DbSet<TUserPhone> UserPhones { get; set; }
        public DbSet<TUserScope> UserScopes { get; set; }
        public DbSet<TUserScopeAlias> UserScopeAliases { get; set; }
        public DbSet<TUserSession> UserSessions { get; set; }
        public DbSet<TUserStatus> UserStatuses { get; set; }
        public DbSet<TUserToken> UserTokens { get; set; }
        public DbSet<TUserTokenType> UserTokenTypes { get; set; }
        public DbSet<TUserType> UserTypes { get; set; }

        protected UserDb(RelationalDbProvider provider) : base(provider) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasOneToMany<TUserScope, TUserScopeAlias>(x => x.UserScopeAliases, x => x.UserScope, x => x.UserScopeId)
                .HasOneToMany<TUserScope, TUserType>(x => x.UserTypes, x => x.UserScope, x => x.UserScopeId)
                .HasOneToMany<TUserType, TUserAttributeType>(x => x.UserAttributeTypes, x => x.UserType, x => x.UserTypeId)
                .HasOneToMany<TUserType, TUserCredentialType>(x => x.UserCredentialTypes, x => x.UserType, x => x.UserTypeId)
                .HasOneToMany<TUserType, TUserEmail>(x => x.UserEmails, x => x.UserType, x => x.UserTypeId)
                .HasOneToMany<TUserType, TUserGroup>(x => x.UserGroups, x => x.UserType, x => x.UserTypeId)
                .HasOneToMany<TUserType, TUserPhone>(x => x.UserPhones, x => x.UserType, x => x.UserTypeId)
                .HasOneToMany<TUserType, TUserStatus>(x => x.UserStatuses, x => x.UserType, x => x.UserTypeId)
                .HasOneToMany<TUserType, TUserTokenType>(x => x.UserTokenTypes, x => x.UserType, x => x.UserTypeId)
                .HasOneToMany<TUserAttributeType, TUserAttribute>(x => x.UserAttributes, x => x.UserAttributeType, x => x.UserAttributeTypeId)
                .HasOneToMany<TUserCredentialType, TUserCredential>(x => x.UserCredentials, x => x.UserCredentialType, x => x.UserCredentialTypeId)
                .HasOneToMany<TUserTokenType, TUserToken>(x => x.UserTokens, x => x.UserTokenType, x => x.UserTokenTypeId)
                .HasOneToMany<TUserStatus, TUser>(x => x.Users, x => x.UserStatus, x => x.UserStatusId)
                .HasOneToMany<TUserGroup, TUserGroupUser>(x => x.UserGroupUsers, x => x.UserGroup, x => x.UserGroupId)
                .HasOneToMany<TUser, TUserAttribute>(x => x.UserAttributes, x => x.User, x => x.UserId)
                .HasOneToMany<TUser, TUserCredential>(x => x.UserCredentials, x => x.User, x => x.UserId)
                .HasOneToMany<TUser, TUserGroupUser>(x => x.UserGroupUsers, x => x.User, x => x.UserId)
                .HasOneToMany<TUser, TUserToken>(x => x.UserTokens, x => x.User, x => x.UserId)
                .HasOneToMany<TUser, TUserSession>(x => x.UserSessions, x => x.User, x => x.UserId)
                .HasOneToOne<TUser, TUserEmail>(x => x.UserEmail, x => x.User, x => x.UserId)
                .HasOneToOne<TUser, TUserPhone>(x => x.UserPhone, x => x.User, x => x.UserId);
                
        }
    }
}