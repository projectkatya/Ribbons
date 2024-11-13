using System.Collections.Generic;

namespace Ribbons.Users.Services.Models
{
    public class CreateUserTypeResponse
    {
        public CreateUserTypeResponseCode Status { get; internal set; }
        public string Message { get; internal set; }
        public List<string> ValidationErrors { get; internal set; }
    }
}