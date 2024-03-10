namespace Ribbons.Users.Authentication.Models
{
    public enum LoginStatus
    {
        Ok,
        RequestInvalid,
        CredentialsInvalid,
        UserNotFound,
        DomainInvalid,
        Error
    }
}