using System;
using System.Collections.Generic;

namespace Ribbons.Users.Authentication
{
    public abstract class UserAuthenticatorResponse<TStatus> where TStatus : Enum
    {
        public UserAuthenticatorAction Action { get; }
        public TStatus Status { get; internal set; }
        public Dictionary<string, string> ValidationErrors { get; internal set; }

        protected UserAuthenticatorResponse(UserAuthenticatorAction action)
        {
            Action = action;
        }
    }
}