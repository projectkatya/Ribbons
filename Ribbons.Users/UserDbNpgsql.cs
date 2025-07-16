using Ribbons.Data;

namespace Ribbons.Users;

public class UserDbNpgsql
{
	public UserDbNpgsql() : base(DatabaseProvider.Npgsql)
	{
	}
}