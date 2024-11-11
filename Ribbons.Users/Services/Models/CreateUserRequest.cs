using System.ComponentModel.DataAnnotations;

namespace Ribbons.Users.Services.Models
{
    public class CreateUserRequest
    {
        [Required]
        public string UserType { get; set; }
        
        [Required]
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}