using Ribbons.Users.Definitions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users
{
    [Table(TableNames.UserPassword)]
    public class UserPassword
    {
        [Column(ColumnNames.UserId)]
        [Key]
        public long UserId { get; set; }

        [Column(ColumnNames.CreatedDate)]
        [Required]
        public DateTime CreatedDate { get; set; }

        [Column(ColumnNames.ModifiedDate)]
        [Required]
        public DateTime ModifiedDate { get; set; }

        [Column(ColumnNames.ExpiryDate)]
        public DateTime? ExpiryDate { get; set; }

        [Column(ColumnNames.PasswordSalt)]
        [MaxLength(ColumnConstraints.PasswordSaltMaxLength)]
        [Required]
        public byte[] PasswordSalt { get; set; }

        [Column(ColumnNames.PasswordHash)]
        [MaxLength(ColumnConstraints.PasswordHashMaxLength)]
        [Required]
        public byte[] PasswordHash { get; set; }
    }
}
