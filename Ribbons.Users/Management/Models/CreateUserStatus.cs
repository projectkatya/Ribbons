namespace Ribbons.Users.Management.Models
{
    public enum CreateUserStatus
    {
        Ok,
        RequestInvalid,
        DomainInvalid,
        UserNameTaken,
        EmailAddressTaken,
        PhoneNumberTaken,
        Error,
        UserTypeInvalid
    }
}