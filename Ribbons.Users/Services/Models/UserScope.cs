using System.Collections.Generic;

namespace Ribbons.Users.Services.Models
{
    public class UserScope
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Aliases { get; set; }
    }
}