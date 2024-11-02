using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ribbons.Data
{
    public class RelationalDbManager : IRelationalDbManager
    {
        protected RelationalDbConfig Configuration { get; }
        protected Dictionary<RelationalDbProvider, Func<RelationalDb>> Factories { get; }

        public RelationalDbManager(IOptions<RelationalDbConfig> options)
        {
            Configuration = options.Value;
            Factories = [];
        }

        public RelationalDb GetDatabase()
        {
            return CreateInstance();
        }

        public async Task<RelationalDb> GetDatabaseAsync()
        {
            return await Task.FromResult(CreateInstance());
        }

        public RelationalDbManager RegisterFactory(RelationalDbProvider provider, Func<RelationalDb> factory)
        {
            Factories[provider] = factory;
            return this;
        }

        protected virtual RelationalDb CreateInstance()
        {
            if (!Factories.TryGetValue(Configuration.Provider, out Func<RelationalDb> factory))
            {
                throw new NotSupportedException($"Provider {Configuration.Provider} is not supported");
            }

            RelationalDb instance = factory();
            
            instance.SetConnectionString(Configuration.ConnectionString);

            return instance;
        }
    }

    public class RelationalDbManager<TRelationalDb> : RelationalDbManager, IRelationalDbManager<TRelationalDb> where TRelationalDb : RelationalDb
    {
        new protected Dictionary<RelationalDbProvider, Func<TRelationalDb>> Factories { get; }

        public RelationalDbManager(IOptions<RelationalDbConfig> options) : base(options)
        {
            Factories = [];
        }

        new public TRelationalDb GetDatabase()
        {
            return CreateInstance();
        }

        new public async Task<TRelationalDb> GetDatabaseAsync()
        {
            return await Task.FromResult(CreateInstance());
        }

        public RelationalDbManager<TRelationalDb> RegisterFactory(RelationalDbProvider provider, Func<TRelationalDb> factory)
        {
            Factories[provider] = factory;
            return this;
        }

        protected override TRelationalDb CreateInstance()
        {
            if (!Factories.TryGetValue(Configuration.Provider, out Func<TRelationalDb> factory))
            {
                throw new NotSupportedException($"Provider {Configuration.Provider} not supported for {typeof(TRelationalDb).FullName}");
            }

            TRelationalDb instance = factory();

            instance.SetConnectionString(Configuration.ConnectionString);

            return instance;
        }
    }
}