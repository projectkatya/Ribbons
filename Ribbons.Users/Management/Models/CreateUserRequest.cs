using Ribbons.RegularExpressions;
using Ribbons.Users.Definitions;
using Ribbons.Validation;
using System.ComponentModel.DataAnnotations;

namespace Ribbons.Users.Management.Models
{
    public sealed class CreateUserRequest : UserManagerRequest
    {
        [Required(ErrorMessage = ValidationErrorMessages.Required)]
        [StringLength(LengthConstraints.UserNameLength, ErrorMessage = ValidationErrorMessages.LengthInvalid)]
        [Regex(RegexPatternType.AlphaNumericDotUnderscore, ErrorMessage = ValidationErrorMessages.PatternInvalid)]
        public string UserName { get; set; }

        [Required(ErrorMessage = ValidationErrorMessages.Required)]
        [StringLength(LengthConstraints.EmailAddressLength, ErrorMessage = ValidationErrorMessages.LengthInvalid)]
        public string EmailAddress { get; set; }

        [StringLength(LengthConstraints.PhoneNumberLength, ErrorMessage = ValidationErrorMessages.LengthInvalid)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = ValidationErrorMessages.Required)]
        [StringLength(LengthConstraints.FirstNameLength, ErrorMessage = ValidationErrorMessages.LengthInvalid)]
        public string FirstName { get; set; }

        [StringLength(LengthConstraints.LastNameLength, ErrorMessage = ValidationErrorMessages.LengthInvalid)]
        public string LastName { get; set; }

        [Required(ErrorMessage = ValidationErrorMessages.Required)]
        public string Password { get; set; }
    }
}