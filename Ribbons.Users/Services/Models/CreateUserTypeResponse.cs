namespace Ribbons.Users.Services.Models
{
    public sealed class CreateUserTypeResponse : UserManagerResponse<CreateUserTypeResponseCode>
    {
        public long? UserTypeId { get; internal set; }
    }
}