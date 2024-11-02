using System.Threading.Tasks;

namespace Ribbons.Data
{
    public interface IRelationalDbManager
    {
        RelationalDb GetDatabase();
        Task<RelationalDb> GetDatabaseAsync();
    }

    public interface IRelationalDbManager<TRelationalDb> : IRelationalDbManager where TRelationalDb : RelationalDb
    {
        new TRelationalDb GetDatabase();
        new Task<TRelationalDb> GetDatabaseAsync();
    }
}