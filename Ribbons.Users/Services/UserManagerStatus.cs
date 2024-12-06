namespace Ribbons.Users.Services
{
    public enum UserManagerStatus
    {
        Undefined = 0,
        Ok = 1,
        Invalid = 2,
        Error = 3,
        CodeInUse = 4,
        NameInUse = 5,
        NotFound = 6
    }
}