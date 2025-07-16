using Ribbons.Data;

namespace Ribbons.Users;

public abstract class UserDb : Database
{
	protected UserDb(DatabaseProvider provider) : base(provider)
	{
	}
}