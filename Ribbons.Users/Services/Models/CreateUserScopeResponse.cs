using System.Collections.Generic;

namespace Ribbons.Users.Services.Models
{
    public sealed class CreateUserScopeResponse : UserManagerResponse
    {
        public long UserScopeId { get; internal set; }
        public List<CreateUserScopeAliasResponse> Aliases { get; internal set; }
        public CreateUserScopeResponse() : base(UserManagerAction.CreateUserScope) { }
    }
}