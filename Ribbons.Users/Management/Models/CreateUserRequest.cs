using Ribbons.Users.Definitions;
using System.ComponentModel.DataAnnotations;

namespace Ribbons.Users.Management.Models
{
    public sealed class CreateUserRequest : UserManagerRequest
    {
        [Required]
        [StringLength(LengthConstraints.UserNameLength)]
        public string UserName { get; set; }

        [Required]
        [StringLength(LengthConstraints.EmailAddressLength)]
        public string EmailAddress { get; set; }

        [StringLength(LengthConstraints.PhoneNumberLength)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(LengthConstraints.FirstNameLength)]
        public string FirstName { get; set; }

        [StringLength(LengthConstraints.LastNameLength)]
        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}