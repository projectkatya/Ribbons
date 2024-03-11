namespace Ribbons.Users.Management.Models
{
    public sealed class CreateUserResponse : UserManagerResponse<CreateUserStatus>
    {
        public CreateUserResponse() : base(UserManagerAction.CreateUser) { }
    }
}