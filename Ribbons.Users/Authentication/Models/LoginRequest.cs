using Ribbons.RegularExpressions;
using Ribbons.Validation;
using System.ComponentModel.DataAnnotations;

namespace Ribbons.Users.Authentication.Models
{
    public sealed class LoginRequest : UserAuthenticatorRequest
    {
        [Required(ErrorMessage = ValidationErrorMessages.Required)]
        [Regex(RegexPatternType.AlphaNumericDotUnderscore, ErrorMessage = ValidationErrorMessages.PatternInvalid)]
        public string UserIdentifier { get; set; }

        [Required]
        public string Password { get; set; }
    }
}