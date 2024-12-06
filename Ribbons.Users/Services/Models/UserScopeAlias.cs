using Ribbons.Users.Definitions;
using System.ComponentModel.DataAnnotations;

namespace Ribbons.Users.Services.Models
{
    public class UserScopeAlias
    {
        [Required]
        [StringLength(DataConstraints.CodeMaxLength)]
        public string Scope { get; set; }

        [Required]
        [StringLength(DataConstraints.CodeMaxLength)]
        public string Code { get; set; }

        [Required()]
        [StringLength(DataConstraints.NameMaxLength)]
        public string Name { get; set; }

        [StringLength(DataConstraints.DescriptionLength)]
        public string Description { get; set; }
    }
}