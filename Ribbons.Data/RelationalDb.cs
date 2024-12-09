using Microsoft.EntityFrameworkCore;
using System;

namespace Ribbons.Data;

public abstract class RelationalDb : DbContext
{
    internal RelationalDbProvider Provider { get; }

    protected RelationalDb(RelationalDbProvider provider)
    {
        Provider = provider;
    }

    public void SetConnectionString(string connectionString)
    {
        Database.SetConnectionString(connectionString);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseLazyLoadingProxies();

        switch (Provider)
        {
            case RelationalDbProvider.MsSql:
                options.UseSqlServer();
                break;
            case RelationalDbProvider.Npgsql:
                options.UseNpgsql();
                break;
            case RelationalDbProvider.Sqlite:
                options.UseSqlite();
                break;
            default:
                throw new NotSupportedException($"Provider {Provider} is not supported");
        }

        base.OnConfiguring(options);
    }
}