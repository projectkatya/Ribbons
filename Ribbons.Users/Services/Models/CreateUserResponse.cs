namespace Ribbons.Users.Services.Models
{
    public sealed class CreateUserResponse : UserManagerResponse<CreateUserResponseCode>
    {
        public long? UserId { get; internal set; }
    }
}