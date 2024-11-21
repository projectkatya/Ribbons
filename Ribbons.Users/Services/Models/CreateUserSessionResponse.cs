namespace Ribbons.Users.Services.Models
{
    public class CreateUserSessionResponse : UserManagerResponse<CreateUserSessionResponseCode>
    {
        public string SessionId { get; set; }
        public string SessionSecret { get; set; }
    }
}