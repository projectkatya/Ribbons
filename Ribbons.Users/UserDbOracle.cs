using Ribbons.Data;

namespace Ribbons.Users;

public class UserDbOracle : UserDb
{
	public UserDbOracle() : base(DatabaseProvider.Oracle)
	{
	}
}