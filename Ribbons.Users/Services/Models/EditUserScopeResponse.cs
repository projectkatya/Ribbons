namespace Ribbons.Users.Services.Models
{
    public sealed class EditUserScopeResponse : UserManagerResponse
    {
        public EditUserScopeResponse() : base(UserManagerAction.EditUserScope) { }
    }
}