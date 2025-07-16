using Ribbons.Data;

namespace Ribbons.Users;

public class UserDbMsSql : UserDb
{
	public UserDbMsSql() : base(DatabaseProvider.MsSql)
	{
	}
}