using Microsoft.EntityFrameworkCore;
using Ribbons.Users.Definitions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users
{
    [Table(TableNames.UserPassword)]
    [Index(nameof(CreatedDate))]
    [Index(nameof(ModifiedDate))]
    [Index(nameof(IsExpired))]
    [Index(nameof(ExpiryDate))]
    public class UserPassword
    {
        [Column(ColumnNames.UserId)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long UserId { get; set; }

        [Column(ColumnNames.PasswordSalt)]
        [Required]
        [MaxLength(ColumnConstraints.PasswordSaltLength)]
        public byte[] PasswordSalt { get; set; }

        [Column(ColumnNames.PasswordHash)]
        [Required]
        [MaxLength(ColumnConstraints.PasswordHashLength)]
        public byte[] PasswordHash { get; set; }

        [Column(ColumnNames.CreatedDate)]
        [Required]
        public DateTime CreatedDate { get; set; }

        [Column(ColumnNames.ModifiedDate)]
        [Required]
        public DateTime ModifiedDate { get; set; }

        [Column(ColumnNames.IsExpired)]
        [Required]
        public bool IsExpired { get; set; }

        [Column(ColumnNames.ExpiryDate)]
        public DateTime? ExpiryDate { get; set; }

        public virtual User User { get; set; }
    }
}