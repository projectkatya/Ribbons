namespace Ribbons.Data
{
    public interface IDatabaseManager
    {
        Database GetDatabase();
    }

    public interface IDatabaseManager<TDatabase> : IDatabaseManager where TDatabase : Database
    {
        new TDatabase GetDatabase();
    }
}