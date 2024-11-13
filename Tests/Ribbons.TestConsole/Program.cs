using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Ribbons.Data;
using Ribbons.Users.Data;
using Ribbons.Users.Services;
using Ribbons.Users.Services.Models;

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

            ILoggerFactory loggerFactory = NullLoggerFactory.Instance;

            UserManager userManager = new UserManager(loggerFactory.CreateLogger<UserManager>(), userDbManager);

            for (int i = 0; i < 10000; i++)
            {
                string userTypeCode = $"usertype{i.ToString().PadLeft(10, '0')}";

                await userManager.CreateUserTypeAsync(new CreateUserTypeRequest
                {
                    Code = userTypeCode,
                    Name = userTypeCode,
                    Description = userTypeCode
                });



                for (int j = 0; j < 100; j++)
                {
                    string userStatusCode = $"{userTypeCode}_status{j.ToString().PadLeft(10, '0')}";

                    await userManager.CreateUserStatusAsync(new CreateUserStatusRequest
                    {
                        UserType = userTypeCode,
                        Code = userStatusCode,
                        Name = userStatusCode,
                        Description = userStatusCode
                    });
                }
            }
        }
    }
}