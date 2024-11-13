namespace Ribbons.Users.Services.Models
{
    public enum CreateUserStatusResponseCode
    {
        Ok = 0,
        CodeInUse = 1,
        NameInUse = 2,
        InvalidRequest = 3,
        Error = 4,
        UserTypeNotFound = 5
    }
}