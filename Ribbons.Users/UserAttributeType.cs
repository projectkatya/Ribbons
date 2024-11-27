using Microsoft.EntityFrameworkCore;
using Ribbons.Users.Definitions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users
{
    [Table(TableNames.UserAttributeType)]
    [Index(nameof(UserTypeId))]
    [Index(nameof(Code))]
    [Index(nameof(UserTypeId), nameof(Code), IsUnique = true)]
    [Index(nameof(ValueType))]
    public class UserAttributeType
    {
        [Column(ColumnNames.UserAttributeTypeId)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserAttributeTypeId { get; set; }

        [Column(ColumnNames.UserTypeId)]
        [Required]
        public long UserTypeId { get; set; }

        [Column(ColumnNames.Code)]
        [StringLength(DataConstraints.CodeLength)]
        [Required]
        public string Code { get; set; }

        [Column(ColumnNames.Name)]
        [StringLength(DataConstraints.NameLength)]
        [Required]
        public string Name { get; set; }

        [Column(ColumnNames.Description)]
        [StringLength(DataConstraints.DescriptionLength)]
        public string Description { get; set; }

        [Column(ColumnNames.ValueType)]
        [Required]
        public ValueType ValueType { get; set; }

        public virtual ICollection<UserAttribute> UserAttributes { get; set; }
        public virtual UserType UserType { get; set; }
    }
}