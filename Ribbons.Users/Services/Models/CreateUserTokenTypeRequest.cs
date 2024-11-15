using Ribbons.Users.Definitions;
using System.ComponentModel.DataAnnotations;

namespace Ribbons.Users.Services.Models
{
    public class CreateUserTokenTypeRequest
    {
        [Required]
        [StringLength(DataConstraints.CodeLength)]
        public string UserType { get; set; }

        [Required]
        [StringLength(DataConstraints.CodeLength)]
        public string Code { get; set; }

        [Required]
        [StringLength(DataConstraints.NameLength)]
        public string Name { get; set; }

        [StringLength(DataConstraints.DescriptionLength)]
        public string Description { get; set; }
    }
}