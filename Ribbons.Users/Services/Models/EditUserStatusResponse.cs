namespace Ribbons.Users.Services.Models;

public sealed class EditUserStatusResponse : UserManagerResponse
{
    public EditUserStatusResponse() : base(UserManagerAction.EditUserStatus) { }
}