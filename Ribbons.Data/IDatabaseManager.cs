using System.Threading.Tasks;

namespace Ribbons.Data
{
    public interface IDatabaseManager
    {
        Database GetDatabase(string identifier = null);
        Task<Database> GetDatabaseAsync(string identifier = null);
        MigrationStatus Migrate(string identifier = null);
        Task<MigrationStatus> MigrateAsync(string identifier = null);
    }

    public interface IDatabaseManager<TDatabase> : IDatabaseManager where TDatabase : Database
    {
        
    }
}