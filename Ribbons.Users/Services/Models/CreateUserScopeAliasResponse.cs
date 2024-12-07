namespace Ribbons.Users.Services.Models
{
	public sealed class CreateUserScopeAliasResponse : UserManagerResponse
	{
		public long UserScopeAliasId { get; set; }
		public CreateUserScopeAliasResponse() : base(UserManagerAction.CreateUserScopeAlias) { }
	}
}