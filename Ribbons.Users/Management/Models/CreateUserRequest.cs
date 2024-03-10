namespace Ribbons.Users.Management.Models
{
    public sealed class CreateUserRequest : UserManagerRequest
    {
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}