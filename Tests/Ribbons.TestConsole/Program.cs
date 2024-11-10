using Ribbons.Data;
using Ribbons.Users.Data;

namespace Ribbons.TestConsole
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            UserDbConfigProvider userDbConfigProvider = new UserDbConfigProvider(new UserDbConfig
            {
                Provider = RelationalDbProvider.MsSql,
                ConnectionString = "server=localhost;database=ribbons_users;user id=sa;password=ASD123!@#;trustservercertificate=true"
            });

            IRelationalDbManager<UserDb> userDbManager = new UserDbManager().AddConfigurationProvider(userDbConfigProvider);

            await userDbManager.MigrateAsync();
        }
    }
}