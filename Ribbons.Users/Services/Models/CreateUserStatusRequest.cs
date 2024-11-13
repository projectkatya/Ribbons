using Ribbons.Users.Definitions;
using System.ComponentModel.DataAnnotations;

namespace Ribbons.Users.Services.Models
{
    public class CreateUserStatusRequest
    {
        [Required(ErrorMessage = "UserType is required")]
        [StringLength(DataConstraints.CodeLength)]
        public string UserType { get; set; }

        [Required(ErrorMessage = "Code is required")]
        [StringLength(DataConstraints.CodeLength)]
        public string Code { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(DataConstraints.NameLength)]
        public string Name { get; set; }

        [StringLength(DataConstraints.DescriptionLength)]
        public string Description { get; set; }
    }
}