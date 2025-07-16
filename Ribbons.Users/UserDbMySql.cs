using Ribbons.Data;

namespace Ribbons.Users;

public class UserDbMySql : UserDb
{
	public UserDbMySql() : base(DatabaseProvider.MySql)
	{
	}
}