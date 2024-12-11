namespace Ribbons.Users.Services.Models;

public sealed class CreateUserTokenTypeResponse : UserManagerResponse
{
    public CreateUserTokenTypeResponse() : base(UserManagerAction.CreateUserType) { }
}