using Microsoft.Extensions.Options;
using Ribbons.Data;

namespace Ribbons.Users.Data;

public class UserDbConfig : RelationalDbConfig, IOptions<UserDbConfig>
{
    public UserDbConfig Value => this;
}