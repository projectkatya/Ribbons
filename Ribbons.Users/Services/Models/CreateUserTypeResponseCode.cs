namespace Ribbons.Users.Services.Models
{
    public enum CreateUserTypeResponseCode
    {
        Ok = 0,
        CodeInUse = 1,
        NameInUse = 2,
        InvalidRequest = 3,
        Error = 4
    }
}