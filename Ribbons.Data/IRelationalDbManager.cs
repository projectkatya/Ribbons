using System;
using System.Threading.Tasks;

namespace Ribbons.Data
{
    public interface IRelationalDbManager
    {
        RelationalDb GetDatabase(string configurationName = null);
        Task<RelationalDb> GetDatabaseAsync(string configurationName = null);
        IRelationalDbManager AddConfigurationProvider(IRelationalDbConfigProvider configurationProvider);
        IRelationalDbManager AddProvider<T>() where T : RelationalDb, new();

    }

    public interface IRelationalDbManager<TRelationalDb> : IRelationalDbManager where TRelationalDb : RelationalDb
    {
        new TRelationalDb GetDatabase(string configurationName = null);
        new Task<TRelationalDb> GetDatabaseAsync(string configurationName = null);
        new IRelationalDbManager<TRelationalDb> AddProvider<T>() where T : TRelationalDb, new();
    }
}