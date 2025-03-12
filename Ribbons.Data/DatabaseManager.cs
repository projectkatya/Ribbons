using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Ribbons.Data
{
    public abstract class DatabaseManager : IDatabaseManager
    {
        public Database GetDatabase(string identifier = null)
        {
            DatabaseConfig configuration = GetConfiguration(identifier);
            return CreateInstance(configuration);
        }

        public async Task<Database> GetDatabaseAsync(string identifier = null)
        {
            DatabaseConfig configuration = await GetConfigurationAsync(identifier);
            return CreateInstance(configuration);
        }

        public void Migrate(string identifier = null)
        {
            Database instance = GetDatabase(identifier);
            instance.Database.Migrate();
        }

        public async Task MigrateAsync(string identifier = null)
        {
            Database instance = await GetDatabaseAsync(identifier);
            await instance.Database.MigrateAsync();
        }

        protected abstract DatabaseConfig GetConfiguration(string identifier);
        protected abstract Task<DatabaseConfig> GetConfigurationAsync(string identifier);
        protected abstract Database CreateInstance(DatabaseConfig configuration);
    }

    public abstract class DatabaseManager<TDatabase> : DatabaseManager, IDatabaseManager<TDatabase> where TDatabase : Database
    {
        new public TDatabase GetDatabase(string identifier = null)
        {
            DatabaseConfig configuration = GetConfiguration(identifier);
            return CreateInstance(configuration);
        }

        new public async Task<TDatabase> GetDatabaseAsync(string identifier = null)
        {
            DatabaseConfig configuration = await GetConfigurationAsync(identifier);
            return CreateInstance(configuration);
        }

        protected abstract override TDatabase CreateInstance(DatabaseConfig configuration);
    }
}