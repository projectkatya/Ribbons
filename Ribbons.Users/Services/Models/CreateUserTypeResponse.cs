namespace Ribbons.Users.Services.Models;

public sealed class CreateUserTypeResponse : UserManagerResponse
{
	public CreateUserTypeResponse() : base(UserManagerAction.CreateUserType) { }
}