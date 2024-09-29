using Ribbons.Data;

namespace Ribbons.Users.Data
{
    public abstract class UserDb : Database
    {
        protected UserDb(DatabaseProvider provider) : base(provider) { }
    }
}