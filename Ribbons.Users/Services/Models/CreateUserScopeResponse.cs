namespace Ribbons.Users.Services.Models
{
    public sealed class CreateUserScopeResponse : UserManagerResponse
    {
        public long UserScopeId { get; set; }
        public CreateUserScopeResponse() : base(UserManagerAction.CreateUserScope) { }
    }
}