using Microsoft.EntityFrameworkCore;

namespace Ribbons.Data
{
    public abstract class Database : DbContext
    {
        protected DatabaseProvider Provider { get; set; }

        protected Database(DatabaseProvider provider)
        {
            Provider = provider;
        }

        public void SetConnectionString(string connectionString)
        {
            Database.SetConnectionString(connectionString);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();

            switch (Provider)
            {
                case DatabaseProvider.MsSql:
                    optionsBuilder.UseSqlServer();
                    break;
                case DatabaseProvider.MySql:
                    optionsBuilder.UseMySQL();
                    break;
                case DatabaseProvider.Npgsql:
                    optionsBuilder.UseNpgsql();
                    break;
                case DatabaseProvider.Oracle:
                    optionsBuilder.UseOracle();
                    break;
                case DatabaseProvider.Sqlite:
                    optionsBuilder.UseSqlite();
                    break;
            }
        }
    }
}