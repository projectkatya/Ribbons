using Ribbons.Data;
using Ribbons.Serialization;
using Ribbons.Users.Data;
using Ribbons.Users.Services;
using Ribbons.Users.Services.Models;
using System;
using System.Threading.Tasks;

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

            for (int i = 50; i < 60; i++)
            {
                string scopeCode = $"scope{i.ToString().PadLeft(10, '0')}";
                
                CreateUserScopeResponse response = await userManager.CreateUserScopeAsync(new UserScope
                {
                    Code = scopeCode,
                    Name = scopeCode,
                    Description = scopeCode,
                    Aliases = 
                    [
                        new() 
                        {
                            Code = $"{scopeCode}alias",
                            Name = $"{scopeCode}alias",
                            Description = $"{scopeCode}alias"
                        }
                    ]
                });

                Console.WriteLine(response.ToJson(true));
            }
        }
    }
}