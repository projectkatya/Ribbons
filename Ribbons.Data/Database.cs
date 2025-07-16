using Microsoft.EntityFrameworkCore;

namespace Ribbons.Data;

public abstract class Database : DbContext
{
	protected DatabaseProvider Provider { get; }

	protected Database(DatabaseProvider provider)
	{
		Provider = provider;
	}

	public void SetConnectionString(string connectionString)
	{
		Database.SetConnectionString(connectionString);
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		base.OnConfiguring(optionsBuilder);
	}
}