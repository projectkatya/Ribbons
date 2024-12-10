using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ribbons.Data;

public abstract class RelationalDbManager : IRelationalDbManager
{
    protected IRelationalDbConfigProvider ConfigurationProvider { get; set; }
    protected Dictionary<RelationalDbProvider, Func<RelationalDb>> Factories { get; }

    protected RelationalDbManager(IRelationalDbConfigProvider configurationProvider)
    {
        ConfigurationProvider = configurationProvider;
        Factories = [];
    }

    public RelationalDb GetDatabase(string configurationName = null)
    {
        return CreateInstance(ConfigurationProvider?.GetConfiguration(configurationName));
    }

    public async Task<RelationalDb> GetDatabaseAsync(string configurationName = null)
    {
        return CreateInstance(await ConfigurationProvider?.GetConfigurationAsync(configurationName));
    }

    protected IRelationalDbManager AddProvider<T>() where T : RelationalDb, new()
    {
        T instance = new();

        if (instance.Provider == RelationalDbProvider.Undefined)
        {
            throw new InvalidOperationException($"{RelationalDbProvider.Undefined} is not supported");
        }

        Factories[instance.Provider] = () => new T();

        return this;
    }

    public void Migrate(string configurationName = null)
    {
        RelationalDb instance = GetDatabase(configurationName);
        instance.Database.MigrateAsync();
    }

    public async Task MigrateAsync(string configurationName = null)
    {
        RelationalDb instance = await GetDatabaseAsync(configurationName);
        await instance.Database.MigrateAsync();
    }

    protected virtual RelationalDb CreateInstance(RelationalDbConfig configuration)
    {
        if (configuration == null)
        {
            throw new InvalidOperationException($"Unable to create instance. Configuration is not specified");
        }

        if (!Factories.TryGetValue(configuration.Provider, out Func<RelationalDb> factory))
        {
            throw new NotSupportedException($"Provider {configuration.Provider} is not supported");
        }

        RelationalDb instance = factory();

        instance.SetConnectionString(configuration.ConnectionString);

        return instance;
    }
}

public class RelationalDbManager<TRelationalDb> : RelationalDbManager, IRelationalDbManager<TRelationalDb> where TRelationalDb : RelationalDb
{
    new protected Dictionary<RelationalDbProvider, Func<TRelationalDb>> Factories { get; }

    protected RelationalDbManager(IRelationalDbConfigProvider configurationProvider) : base(configurationProvider)
    {
        Factories = [];
    }

    new public TRelationalDb GetDatabase(string configurationName = null)
    {
        return CreateInstance(ConfigurationProvider?.GetConfiguration(configurationName));
    }

    new public async Task<TRelationalDb> GetDatabaseAsync(string configurationName = null)
    {
        return CreateInstance(await ConfigurationProvider?.GetConfigurationAsync(configurationName));
    }

    new protected IRelationalDbManager<TRelationalDb> AddProvider<T>() where T : TRelationalDb, new()
    {
        T instance = new();

        if (instance.Provider == RelationalDbProvider.Undefined)
        {
            throw new InvalidOperationException($"{RelationalDbProvider.Undefined} is not supported");
        }

        Factories[instance.Provider] = () => new T();

        return this;
    }

    protected override TRelationalDb CreateInstance(RelationalDbConfig configuration)
    {
        if (!Factories.TryGetValue(configuration.Provider, out Func<TRelationalDb> factory))
        {
            throw new NotSupportedException($"Provider {configuration.Provider} not supported for {typeof(TRelationalDb).FullName}");
        }

        TRelationalDb instance = factory();

        instance.SetConnectionString(configuration.ConnectionString);

        return instance;
    }
}