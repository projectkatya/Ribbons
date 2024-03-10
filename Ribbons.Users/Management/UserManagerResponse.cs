using System;

namespace Ribbons.Users.Management
{
    public abstract class UserManagerResponse<TStatus> where TStatus : Enum
    {
        public UserManagerAction Action { get; }
        public TStatus Status { get; internal set; }

        protected UserManagerResponse(UserManagerAction action)
        {
            Action = action;
        }
    }
}