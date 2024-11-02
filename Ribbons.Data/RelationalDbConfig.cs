using Microsoft.Extensions.Options;

namespace Ribbons.Data
{
    public class RelationalDbConfig : IOptions<RelationalDbConfig>
    {
        public RelationalDbProvider Provider { get; set; }
        public string ConnectionString { get; set; }
        public RelationalDbConfig Value => this;
    }
}