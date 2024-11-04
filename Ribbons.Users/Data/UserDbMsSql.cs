using Ribbons.Data;

namespace Ribbons.Users.Data
{
    public class UserDbMsSql : UserDb
    {
        public UserDbMsSql() : base(RelationalDbProvider.MsSql) { }
    }
}