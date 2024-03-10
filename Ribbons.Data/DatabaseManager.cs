using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System.Threading.Tasks;

namespace Ribbons.Data
{
    public abstract class DatabaseManager<TDatabase> : IDatabaseManager<TDatabase> where TDatabase : Database
    {
        protected ILogger Logger { get; set; } = NullLogger.Instance;

        protected DatabaseManager(ILogger logger)
        {
            Logger = logger;
        }

        public TDatabase GetDatabase(string identifier = null)
        {
            DatabaseConfig configuration = GetConfiguration(identifier);

            return CreateInstance(configuration);
        }

        public async Task<TDatabase> GetDatabaseAsync(string identifier = null)
        {
            DatabaseConfig configuration = await GetConfigurationAsync(identifier);

            return CreateInstance(configuration);
        }

        public void Migrate(string identifier = null)
        {
            TDatabase instance = GetDatabase(identifier);

            if (instance == null)
            {
                Logger.LogTrace("Unable to migrate database. Could not create instance of {type}", instance.GetType().FullName);
                return;
            }

            instance.Database.Migrate();
        }

        public async Task MigrateAsync(string identifier = null)
        {
            TDatabase instance = await GetDatabaseAsync(identifier);

            if (instance == null)
            {
                Logger.LogTrace("Unable to migrate database. Could not create instance of {type}", instance.GetType().FullName);
                return;
            }

            await instance.Database.MigrateAsync();
        }

        protected abstract DatabaseConfig GetConfiguration(string identifier);
        protected abstract Task<DatabaseConfig> GetConfigurationAsync(string identifier);
        protected abstract TDatabase CreateInstance(DatabaseConfig configuration);
    }
}