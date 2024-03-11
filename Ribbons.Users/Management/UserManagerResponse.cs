using System;
using System.Collections.Generic;

namespace Ribbons.Users.Management
{
    public abstract class UserManagerResponse<TStatus> where TStatus : Enum
    {
        public UserManagerAction Action { get; }
        public TStatus Status { get; internal set; }
        public Dictionary<string, string> ValidationErrors { get; set; }

        protected UserManagerResponse(UserManagerAction action)
        {
            Action = action;
            ValidationErrors = [];
        }
    }
}