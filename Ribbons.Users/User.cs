using Microsoft.EntityFrameworkCore;
using Ribbons.Users.Definitions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users
{
    [Table(TableNames.User)]
    [Index(nameof(CreatedDate))]
    [Index(nameof(ModifiedDate))]
    [Index(nameof(UserTypeId))]
    [Index(nameof(UserName))]
    [Index(nameof(UserTypeId), nameof(UserName), IsUnique = true)]
    public class User
    {
        [Column(ColumnNames.UserId)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserId { get; set; }

        [Column(ColumnNames.CreatedDate)]
        [Required]
        public DateTime CreatedDate { get; set; }

        [Column(ColumnNames.ModifiedDate)]
        [Required]
        public DateTime ModifiedDate { get; set; }

        [Column(ColumnNames.UserTypeId)]
        [Required]
        public long UserTypeId { get; set; }

        [Column(ColumnNames.UserName)]
        [Required]
        public string UserName { get; set; }
    }
}