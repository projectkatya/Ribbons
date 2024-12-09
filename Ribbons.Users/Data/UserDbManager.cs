using Ribbons.Data;

namespace Ribbons.Users.Data;

public class UserDbManager : RelationalDbManager<UserDb>
{
    public UserDbManager()
    {
        AddProvider<UserDbMsSql>();
        AddProvider<UserDbMySql>();
        AddProvider<UserDbNpgsql>();
        AddProvider<UserDbOracle>();
        AddProvider<UserDbSqlite>();
    }
}