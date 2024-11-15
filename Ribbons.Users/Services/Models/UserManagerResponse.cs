using System;
using System.Collections.Generic;

namespace Ribbons.Users.Services.Models
{
    public abstract class UserManagerResponse<TResponseCode> where TResponseCode : Enum
    {
        public TResponseCode Status { get; internal set; }
        public string Message { get; internal set; }
        public List<string> ValidationErrors { get; internal set; }
    }
}