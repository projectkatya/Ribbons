using System.Collections.Generic;

namespace Ribbons.Users.Services.Models
{
    public sealed class EditUserScopeResponse : UserManagerResponse
    {
        public long UserScopeId { get; internal set; }
        public EditUserScopeResponse() : base(UserManagerAction.EditUserScope) { }
    }
}