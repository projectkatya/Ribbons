using Microsoft.EntityFrameworkCore;
using Ribbons.Users.Definitions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users
{
    [Table(TableNames.UserCredential)]
    [Index(nameof(UserId))]
    [Index(nameof(UserCredentialTypeId))]
    [Index(nameof(UserId), nameof(UserCredentialTypeId), IsUnique = true)]
    [Index(nameof(CreatedDate))]
    [Index(nameof(ModifiedDate))]
    [Index(nameof(IsExpired))]
    [Index(nameof(ExpiryDate))]
    public class UserCredential
    {
        [Column(ColumnNames.UserCredentialId)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserCredentialId { get; set; }

        [Column(ColumnNames.UserId)]
        [Required]
        public long UserId { get; set; }

        [Column(ColumnNames.UserCredentialTypeId)]
        [Required]
        public long UserCredentialTypeId { get; set; }

        [Column(ColumnNames.PasswordSalt)]
        [Required]
        [MaxLength(DataConstraints.PasswordSaltLength)]
        public byte[] PasswordSalt { get; set; }

        [Column(ColumnNames.PasswordHash)]
        [Required]
        [MaxLength(DataConstraints.PasswordHashLength)]
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
        public virtual UserCredentialType UserCredentialType { get; set; }
    }
}