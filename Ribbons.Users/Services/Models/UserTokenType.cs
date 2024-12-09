namespace Ribbons.Users.Services.Models;

public sealed class UserTokenType
{
    public string Scope { get; set; }
    public string UserType { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}