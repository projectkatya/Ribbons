using Ribbons.Data;

namespace Ribbons.Users.Data
{
    public class UserDbNpgsql : UserDb
    {
        public UserDbNpgsql() : base(RelationalDbProvider.Npgsql) { }
    }
}