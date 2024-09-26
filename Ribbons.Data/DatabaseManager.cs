using Microsoft.Extensions.Options;

namespace Ribbons.Data
{
    public abstract class DatabaseManager : IDatabaseManager
    {
        protected DatabaseConfig Configuration { get; set; }

        public DatabaseManager(IOptions<DatabaseConfig> options)
        {
            Configuration = options.Value;
        }

        public abstract Database GetDatabase();
    }

    public abstract class DatabaseManager<TDatabase> : DatabaseManager, IDatabaseManager<TDatabase> where TDatabase : Database
    {
        protected DatabaseManager(IOptions<DatabaseConfig> options) : base(options) { }

        public override abstract TDatabase GetDatabase();
    }
}