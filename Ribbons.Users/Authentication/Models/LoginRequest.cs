namespace Ribbons.Users.Authentication.Models
{
    public sealed class LoginRequest : UserAuthenticatorRequest
    {
        public string UserIdentifier { get; set; }
        public string Password { get; set; }
    }
}