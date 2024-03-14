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

        public void Migrate(string identifier = null)
        {
            try
            {
                Database instance = GetDatabase(identifier);

                if (instance == null)
                {
                    Logger.LogError("Failed to migrate database. Instance was not initiated correctly.");
                    return;
                }

                instance.Database.Migrate();
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to migrate database. An exception occured. {ex}", ex);
            }
        }

        public async Task MigrateAsync(string identifier = null)
        {
            try
            {
                Database instance = await GetDatabaseAsync(identifier);

                if (instance == null)
                {
                    Logger.LogError("Failed to migrate database. Instance was not initiated correctly.");
                    return;
                }

                await instance.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to migrate database. An exception occured. {ex}", ex);
            }
        }

        protected abstract DatabaseConfig GetConfiguration(string identifier);
        protected abstract Task<DatabaseConfig> GetConfigurationAsync(string identifier);
        protected abstract Database CreateInstance(DatabaseConfig configuration);
    }

    public abstract class DatabaseManager<TDatabase> : IDatabaseManager<TDatabase> where TDatabase : Database
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

        public void Migrate(string identifier = null)
        {
            try
            {
                Database instance = GetDatabase(identifier);

                if (instance == null)
                {
                    Logger.LogTrace("Failed to migrate database. Could not create instance of {type}", typeof(TDatabase).FullName);
                    return;
                }

                instance.Database.Migrate();
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to migrate database of type {type}. An exception occured. {ex}", typeof(TDatabase).FullName, ex);
            }
        }

        public async Task MigrateAsync(string identifier = null)
        {
            try
            {
                Database instance = await GetDatabaseAsync(identifier);

                if (instance == null)
                {
                    Logger.LogTrace("Failed to migrate database. Could not create instance of {type}", instance.GetType().FullName);
                    return;
                }

                await instance.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to migrate database of type {type}. An exception occured. {ex}", typeof(TDatabase).FullName, ex);
            }
        }

        protected abstract DatabaseConfig GetConfiguration(string identifier);
        protected abstract Task<DatabaseConfig> GetConfigurationAsync(string identifier);
        protected abstract Database CreateInstance(DatabaseConfig configuration);
    }
}