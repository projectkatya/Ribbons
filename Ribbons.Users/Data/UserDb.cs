using Microsoft.EntityFrameworkCore;
using Ribbons.Data;
using Ribbons.Data.Extensions;

namespace Ribbons.Users.Data
{
    public abstract class UserDb : Database
    {
        public DbSet<TUser> Users { get; set; }
        public DbSet<TUserDomain> UserDomains { get; set; }
        public DbSet<TUserDomainAlias> UserDomainAliases { get; set; }

        protected UserDb(DatabaseProvider provider) : base(provider) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasOneToMany<TUserDomain, TUser>(x => x.Users, x => x.UserDomain, x => x.UserDomainId)
                .HasOneToMany<TUserDomain, TUserDomainAlias>(x => x.UserDomainAliases, x => x.UserDomain, x => x.UserDomainId);
        }
    }
}