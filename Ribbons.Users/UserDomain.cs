using Microsoft.EntityFrameworkCore;
using Ribbons.Users.Definitions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users
{
    [Table(TableNames.UserDomain)]
    [Index(nameof(CreatedDate))]
    [Index(nameof(ModifiedDate))]
    [Index(nameof(Code), IsUnique = true)]
    public class UserDomain
    {
        [Column(ColumnNames.UserDomainId)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserDomainId { get; set; }

        [Column(ColumnNames.CreatedDate)]
        [Required]
        public DateTime CreatedDate { get; set; }

        [Column(ColumnNames.ModifiedDate)]
        [Required]
        public DateTime ModifiedDate { get; set; }

        [Column(ColumnNames.Name)]
        [StringLength(ColumnConstraints.NameMaxLength)]
        [Required]
        public string Name { get; set; }

        [Column(ColumnNames.Code)]
        [StringLength(ColumnConstraints.CodeMaxLength)]
        [Required]
        public string Code { get; set; }

        [Column(ColumnNames.Description)]
        [StringLength(ColumnConstraints.DescriptionMaxLength)]
        public string Description { get; set; }
    }
}