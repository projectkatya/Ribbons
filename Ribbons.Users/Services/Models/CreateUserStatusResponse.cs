namespace Ribbons.Users.Services.Models;

public sealed class CreateUserStatusResponse : UserManagerResponse
{
    public CreateUserStatusResponse() : base(UserManagerAction.CreateUserStatus) { }
}