using System.Threading.Tasks;

namespace Ribbons.Data;

public interface IRelationalDbConfigProvider
{
    RelationalDbConfig GetConfiguration(string configurationName);
    Task<RelationalDbConfig> GetConfigurationAsync(string configurationName);
}