using Ribbons.Data;

namespace Ribbons.Users.Data;

public class UserDbMySql : UserDb
{
    public UserDbMySql() : base(RelationalDbProvider.MySql) { }
}