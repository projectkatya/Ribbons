using System.Threading.Tasks;

namespace Ribbons.Data
{
    public interface IDatabaseManager
    {
        Database GetDatabase(string identifier = null);
        Task<Database> GetDatabaseAsync(string identifier = null);
        void Migrate(string identifier = null);
        Task MigrateAsync(string identifier = null);
    }

    public interface IDatabaseManager<TDatabase> : IDatabaseManager where TDatabase : Database
    {
        
    }
}