using System.Threading.Tasks;

namespace Ribbons.Data
{
    public interface IDatabaseManager<TDatabase> where TDatabase : Database
    {
        TDatabase GetDatabase(string identifier = null);
        Task<TDatabase> GetDatabaseAsync(string identifier = null);
        void Migrate(string identifier = null);
        Task MigrateAsync(string identifier = null);
    }
}