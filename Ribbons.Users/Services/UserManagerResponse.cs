using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ribbons.Users.Services
{
    public abstract class UserManagerResponse
    {
        [JsonProperty(Order = -5)]
        public UserManagerAction Action { get; }

        [JsonProperty(Order = -4)]
        public UserManagerStatus Status { get; internal set; }

        [JsonProperty(Order = -3)]
        public string Message { get; internal set; }

        [JsonProperty(Order = -2)]
        public List<string> ValidationErrors { get; internal set; }

        protected UserManagerResponse(UserManagerAction action)
        {
            Action = action;
        }
    }
}