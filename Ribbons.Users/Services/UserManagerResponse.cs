using System.Collections.Generic;

namespace Ribbons.Users.Services
{
    public abstract class UserManagerResponse
    {
        public UserManagerAction Action { get; }
        public UserManagerStatus Status { get; internal set; }
        public string Message { get; internal set; }
        public List<string> ValidationErrors { get; internal set; }

        protected UserManagerResponse(UserManagerAction action)
        {

        }
    }
}