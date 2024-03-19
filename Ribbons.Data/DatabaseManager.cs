using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Ribbons.Data
{
    public abstract class DatabaseManager : IDatabaseManager
    {
        protected ILogger Logger { get; }

        protected DatabaseManager(ILogger logger)
        {
            Logger = logger;
        }

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

        public MigrationStatus Migrate(string identifier = null)
        {
            try
            {
                DatabaseConfig configuration = GetConfiguration(identifier);

                if (configuration == null)
                {
                    Logger.LogError("Failed to migrate database. Configuration is null for database {identifier}", identifier);

                    return MigrationStatus.ConfigurationInvalid;
                }

                Database instance = GetDatabase(identifier);

                if (instance == null)
                {
                    Logger.LogError("Failed to migrate database. Instance was not initiated correctly.");
                    
                    return MigrationStatus.Incomplete;
                }

                instance.Database.Migrate();

                return MigrationStatus.Complete;
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to migrate database. An exception occured. {ex}", ex);

                return MigrationStatus.Error;
            }
        }

        public async Task<MigrationStatus> MigrateAsync(string identifier = null)
        {
            try
            {
                DatabaseConfig configuration = await GetConfigurationAsync(identifier);

                if (configuration == null)
                {
                    Logger.LogError("Failed to migrate database. Configuration is null for database {identifier}", identifier);

                    return MigrationStatus.ConfigurationInvalid;
                }

                Database instance = CreateInstance(configuration);

                if (instance == null)
                {
                    Logger.LogError("Failed to migrate database. Instance was not initiated correctly.");
                    
                    return MigrationStatus.Incomplete;
                }

                await instance.Database.MigrateAsync();

                return MigrationStatus.Complete;
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to migrate database. An exception occured. {ex}", ex);

                return MigrationStatus.Error;
            }
        }

        protected abstract DatabaseConfig GetConfiguration(string identifier);
        protected abstract Task<DatabaseConfig> GetConfigurationAsync(string identifier);
        protected abstract Database CreateInstance(DatabaseConfig configuration);
    }

    public abstract class DatabaseManager<TDatabase> : DatabaseManager, IDatabaseManager<TDatabase> where TDatabase : Database
    {
        protected DatabaseManager(ILogger logger) : base(logger) { }
    }
}