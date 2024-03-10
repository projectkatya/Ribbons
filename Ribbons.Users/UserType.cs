using Microsoft.EntityFrameworkCore;
using Ribbons.Users.Definitions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users
{
    [Table(TableNames.UserType)]
    [Index(nameof(Code), IsUnique = true)]
    public class UserType
    {
        [Column(ColumnNames.UserTypeId)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserTypeId { get; set; }

        [Column(ColumnNames.Code)]
        [Required]
        [StringLength(LengthConstraints.CodeLength)]
        public string Code { get; set; }

        [Column(ColumnNames.Name)]
        [Required]
        [StringLength(LengthConstraints.NameLength)]
        public string Name { get; set; }

        [Column(ColumnNames.Description)]
        [StringLength(LengthConstraints.DescriptionLength)]
        public string Description { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<UserEmail> UserEmails { get; set; }
        public virtual ICollection<UserPhone> UserPhones { get; set; }
    }
}