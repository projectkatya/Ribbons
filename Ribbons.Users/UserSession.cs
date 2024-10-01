using Microsoft.EntityFrameworkCore;
using Ribbons.Users.Definitions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users
{
    [Table(TableNames.UserSession)]
    [Index(nameof(CreatedDate))]
    [Index(nameof(UserId))]
    [Index(nameof(IsVerified))]
    [Index(nameof(VerifiedDate))]
    [Index(nameof(IsLoggedOut))]
    [Index(nameof(LogoutDate))]
    [Index(nameof(IsExpired))]
    [Index(nameof(ExpiryDate))]
    public class UserSession
    {
        [Column(ColumnNames.UserSessionId)]
        [MaxLength(ColumnConstraints.UserSessionIdMaxLength)]
        [Key]
        public byte[] UserSessionId { get; set; }

        [Column(ColumnNames.CreatedDate)]
        [Required]
        public DateTime CreatedDate { get; set; }

        [Column(ColumnNames.UserId)]
        public long UserId { get; set; }

        [Column(ColumnNames.SessionTokenSalt)]
        [MaxLength(ColumnConstraints.SessionTokenSaltMaxLength)]
        [Required]
        public byte[] SessionTokenSalt { get; set; }

        [Column(ColumnNames.SessionTokenHash)]
        [MaxLength(ColumnConstraints.SessionTokenHashMaxLength)]
        [Required]
        public byte[] SessionTokenHash { get; set; }

        [Column(ColumnNames.IsVerified)]
        [Required]
        public bool IsVerified { get; set; }

        [Column(ColumnNames.VerifiedDate)]
        public DateTime? VerifiedDate { get; set; }

        [Column(ColumnNames.IsLoggedOut)]
        [Required]
        public bool IsLoggedOut { get; set; }

        [Column(ColumnNames.LogoutDate)]
        public DateTime? LogoutDate { get; set; }

        [Column(ColumnNames.IsExpired)]
        [Required]
        public bool IsExpired { get; set; }

        [Column(ColumnNames.ExpiryDate)]
        public DateTime? ExpiryDate { get; set; }
    }
}