namespace Ribbons.Users.Services.Models;

public sealed class EditUserCredentialTypeResponse : UserManagerResponse
{
	public EditUserCredentialTypeResponse() : base(UserManagerAction.EditUserCredentialType) { }
}