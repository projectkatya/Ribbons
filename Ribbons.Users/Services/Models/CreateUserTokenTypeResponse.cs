namespace Ribbons.Users.Services.Models
{
    public sealed class CreateUserTokenTypeResponse : UserManagerResponse<CreateUserTokenTypeResponseCode>
    {
        public long? UserTokenTypeId { get; internal set; }
    }
}