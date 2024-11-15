namespace Ribbons.Users.Services.Models
{
    public sealed class CreateUserStatusResponse : UserManagerResponse<CreateUserStatusResponseCode>
    {
        public long? UserStatusId { get; internal set; }
    }
}