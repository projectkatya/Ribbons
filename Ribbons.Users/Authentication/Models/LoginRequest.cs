using System.ComponentModel.DataAnnotations;

namespace Ribbons.Users.Authentication.Models
{
    public sealed class LoginRequest : UserAuthenticatorRequest
    {
        [Required]
        public string UserIdentifier { get; set; }

        [Required]
        public string Password { get; set; }
    }
}