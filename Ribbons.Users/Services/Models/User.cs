using System.Collections.Generic;

namespace Ribbons.Users.Services.Models;

public sealed class User
{
    public string UserType { get; set; }
    public string UserName { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
    public List<UserAttribute> Attributes { get; set; }
    public List<UserGroupUser> Groups { get; set; }
}