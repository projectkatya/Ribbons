namespace Ribbons.Users.Authentication.Models
{
    public struct SessionCredentials
    {
        public string Domain { get; internal set; }
        public string SessionId { get; internal set; }
        public string SessionSecret { get; internal set; }
    }
}