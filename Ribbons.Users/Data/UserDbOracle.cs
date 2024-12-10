using Ribbons.Data;

namespace Ribbons.Users.Data;

public class UserDbOracle : UserDb
{
    public UserDbOracle() : base(RelationalDbProvider.Oracle) { }
}