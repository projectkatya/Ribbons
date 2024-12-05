namespace Ribbons.Users.Services
{
    public enum UserManagerStatus
    {
        Ok = 0,
        Invalid = 1,
        Error = 2,
        CodeInUse = 3,
        NameInUse = 4,
        NotFound = 5
    }
}