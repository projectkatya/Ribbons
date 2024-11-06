using Microsoft.EntityFrameworkCore;
using Ribbons.Users.Definitions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users
{
    [Table(TableNames.UserType)]
    [Index(nameof(Code), IsUnique = true)]
    [Index(nameof(CreatedDate))]
    [Index(nameof(ModifiedDate))]
    public class UserType
    {
        [Column(ColumnNames.UserTypeId)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserTypeId { get; set; }

        [Column(ColumnNames.Code)]
        [Required]
        public string Code { get; set; }

        [Column(ColumnNames.Name)]
        [Required]
        public string Name { get; set; }

        [Column(ColumnNames.Description)]
        public string Description { get; set; }

        [Column(ColumnNames.CreatedDate)]
        [Required]
        public DateTime CreatedDate { get; set; }

        [Column(ColumnNames.ModifiedDate)]
        [Required]
        public DateTime ModifiedDate { get; set; }
    }
}