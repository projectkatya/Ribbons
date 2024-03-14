namespace Ribbons.Users.Authentication.Models
{
    public struct SessionCredentials
    {
        public string SessionId { get; internal set; }
        public string SessionSecret { get; internal set; }
    }
}