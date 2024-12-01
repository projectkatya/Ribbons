using Ribbons.Data;
using Ribbons.Users.Data;
using Ribbons.Users.Definitions;
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

            IUserManager userManager = new UserManager(userDbManager);

            for (int i = 0; i < 10000; i++)
            {
                string userTypeCode = $"usertype_{i.ToString().PadLeft(10, '0')}";

                await userManager.CreateUserTypeAsync(new UserType
                {
                    Code = userTypeCode,
                    Name = userTypeCode,
                    Description = userTypeCode
                });

                for (int j = 0; j < 10; j++)
                {
                    string userAttributeTypeCode = $"userattributetype_{j.ToString().PadLeft(10, '0')}";

                    await userManager.CreateUserAttributeTypeAsync(new UserAttributeType()
                    {
                        UserType = userTypeCode,
                        Code = userAttributeTypeCode,
                        Name = userAttributeTypeCode,
                        Description = userAttributeTypeCode,
                        ValueType = UserAttributeValueType.String
                    });
                }
            }
        }
    }
}