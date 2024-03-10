using Microsoft.EntityFrameworkCore;
using Ribbons.Users.Definitions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users
{
    [Table(TableNames.UserSession)]
    [Index(nameof(UserId))]
    [Index(nameof(CreatedDate))]
    [Index(nameof(IsExpired))]
    [Index(nameof(ExpiryDate))]
    [Index(nameof(IsLoggedOut))]
    [Index(nameof(LogoutDate))]
    public class UserSession
    {
        [Column(ColumnNames.UserSessionId)]
        [Key]
        [MaxLength(LengthConstraints.UserSessionIdLength)]
        public byte[] UserSessionId { get; set; }

        [Column(ColumnNames.UserId)]
        [Required]
        public long UserId { get; set; }

        [Column(ColumnNames.CreatedDate)]
        [Required]
        public DateTime CreatedDate { get; set; }

        [Column(ColumnNames.IsExpired)]
        [Required]
        public bool IsExpired { get; set; }

        [Column(ColumnNames.ExpiryDate)]
        [Required]
        public DateTime ExpiryDate { get; set; }

        [Column(ColumnNames.SessionSecretSalt)]
        [Required]
        [MaxLength(LengthConstraints.SessionSecretSaltLength)]
        public byte[] SessionSecretSalt { get; set; }

        [Column(ColumnNames.SessionSecretHash)]
        [Required]
        [MaxLength(LengthConstraints.SessionSecretHashLength)]
        public byte[] SessionSecretHash { get; set; }

        [Column(ColumnNames.IsLoggedOut)]
        [Required]
        public bool IsLoggedOut { get; set; }

        [Column(ColumnNames.LogoutDate)]
        public DateTime? LogoutDate { get; set; }

        public virtual User User { get; set; }
    }
}