namespace Ribbons.Users.Services.Models
{
	public sealed class CreateUserScopeAliasResponse : UserManagerResponse
	{
		public long? UserScopeAliasId { get; set; }
		public CreateUserScopeAliasResponse(UserManagerAction action) : base(action)
		{
		}
	}
}