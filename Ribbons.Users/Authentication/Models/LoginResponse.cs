using System.Collections.Generic;

namespace Ribbons.Users.Authentication.Models
{
    public sealed class LoginResponse : UserAuthenticatorResponse<LoginStatus>
    {
        private LoginResponse(LoginStatus status) : base(UserAuthenticatorAction.Login)
        {
            Status = status;
        }

        public static LoginResponse Ok() => new(LoginStatus.Ok);
        public static LoginResponse DomainInvalid() => new(LoginStatus.DomainInvalid);
        public static LoginResponse UserTypeInvalid() => new(LoginStatus.UserTypeInvalid);
        public static LoginResponse UserNotFound() => new(LoginStatus.UserNotFound);
        public static LoginResponse CredentialsInvalid() => new(LoginStatus.CredentialsInvalid);
        public static LoginResponse Error() => new(LoginStatus.Error);
        public static LoginResponse RequestInvalid(Dictionary<string, string> validationErrors) => new(LoginStatus.RequestInvalid)
        {
            ValidationErrors = validationErrors
        };
    }
}