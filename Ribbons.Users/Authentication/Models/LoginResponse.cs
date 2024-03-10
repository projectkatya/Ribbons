namespace Ribbons.Users.Authentication.Models
{
    public sealed class LoginResponse : UserAuthenticatorResponse<LoginStatus>
    {
        public LoginResponse() : base(UserAuthenticatorAction.Login) { }
    }
}