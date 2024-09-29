using System.Threading.Tasks;

namespace Ribbons.Data
{
    public abstract class DatabaseManager : IDatabaseManager
    {
        public DatabaseManager() { }

        public Database GetDatabase(string identifier = null)
        {
            return CreateInstance(GetConfiguration(identifier));
        }

        public async Task<Database> GetDatabaseAsync(string identifier = null)
        {
            return CreateInstance(await GetConfigurationAsync(identifier));
        }

        protected abstract Database CreateInstance(DatabaseConfig configuration);
        protected abstract DatabaseConfig GetConfiguration(string identifier);
        protected abstract Task<DatabaseConfig> GetConfigurationAsync(string identifier);
    }

    public abstract class DatabaseManager<TDatabase> : DatabaseManager, IDatabaseManager<TDatabase> where TDatabase : Database
    {
        new public TDatabase GetDatabase(string identifier = null)
        {
            return CreateInstance(GetConfiguration(identifier));
        }

        new public async Task<TDatabase> GetDatabaseAsync(string identifier = null)
        {
            return CreateInstance(await GetConfigurationAsync(identifier));
        }

        protected abstract override TDatabase CreateInstance(DatabaseConfig configuration);
    }
}