using System;
using System.Collections.Generic;

namespace Ribbons.Users.Services.Models
{
    public class CreateUserStatusResponse
    {
        public CreateUserStatusResponseCode Status { get; internal set; }
        public string Message { get; internal set; }
        public List<string> ValidationErrors { get; internal set; }
    }
}