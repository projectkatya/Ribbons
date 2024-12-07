using System.Collections.Generic;

namespace Ribbons.Users.Services.Models
{
    public sealed class EditUserScopeAliasResponse : UserManagerResponse
    {
        public long UserScopeAliasId { get; internal set; }
        public EditUserScopeAliasResponse() : base(UserManagerAction.EditUserScopeAlias) { }
    }
}