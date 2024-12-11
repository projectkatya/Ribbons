namespace Ribbons.Users.Services.Models;

public sealed class CreateUserAttributeTypeResponse : UserManagerResponse
{
    public CreateUserAttributeTypeResponse() : base(UserManagerAction.CreateUserAttributeType) { }
}