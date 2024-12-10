using Ribbons.Data;

namespace Ribbons.Users.Data;

public class UserDbManager : RelationalDbManager<UserDb>
{
    public UserDbManager(IUserDbConfigProvider configProvider) : base(configProvider)
    {
        AddProvider<UserDbMsSql>();
        AddProvider<UserDbMySql>();
        AddProvider<UserDbNpgsql>();
        AddProvider<UserDbOracle>();
        AddProvider<UserDbSqlite>();
    }
}