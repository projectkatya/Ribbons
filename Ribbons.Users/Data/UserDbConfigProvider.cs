using Microsoft.Extensions.Options;
using Ribbons.Data;
using System.Threading.Tasks;

namespace Ribbons.Users.Data;

public sealed class UserDbConfigProvider : IRelationalDbConfigProvider
{
    private UserDbConfig Configuration { get; }

    public UserDbConfigProvider(IOptions<UserDbConfig> options)
    {
        Configuration = options.Value;
    }

    public RelationalDbConfig GetConfiguration(string configurationName)
    {
        return Configuration;
    }

    public async Task<RelationalDbConfig> GetConfigurationAsync(string configurationName)
    {
        return await Task.FromResult(Configuration);
    }
}