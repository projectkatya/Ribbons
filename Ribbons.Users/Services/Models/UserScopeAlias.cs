using Ribbons.Users.Definitions;
using System.ComponentModel.DataAnnotations;

namespace Ribbons.Users.Services.Models
{
    public class UserScopeAlias
    {
        [Required(ErrorMessage = "Code is required for user scope alias")]
        [StringLength(DataConstraints.CodeMaxLength, ErrorMessage = $"Code length invalid for user scope alias", MinimumLength = DataConstraints.CodeMinLength)]
        public string Code { get; set; }

        [Required(ErrorMessage = "Name is required for user scope alias")]
        [StringLength(DataConstraints.NameMaxLength, ErrorMessage = $"Name length invalid for user scope alias", MinimumLength = DataConstraints.NameMinLength)]
        public string Name { get; set; }

        [StringLength(DataConstraints.DescriptionLength)]
        public string Description { get; set; }
    }
}