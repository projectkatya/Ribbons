using Ribbons.Data;

namespace Ribbons.Users;

public class UserDbSqlite : UserDb
{
	public UserDbSqlite(DatabaseProvider provider) : base(provider)
	{
	}
}