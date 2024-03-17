using Ribbons.RegularExpressions;
using Ribbons.Validation;
using System.ComponentModel.DataAnnotations;

namespace Ribbons.Users.Authentication.Models
{
    public sealed class LoginRequest : UserAuthenticatorRequest
    {
        [Required]
        [Regex(RegexPatternType.AlphaNumericDotUnderscore)]
        public string UserIdentifier { get; set; }

        [Required]
        public string Password { get; set; }
    }
}