using Microsoft.EntityFrameworkCore;
using Ribbons.Users.Definitions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users
{
    [Table(TableNames.UserToken)]
    [Index(nameof(CreatedDate))]
    [Index(nameof(UserId))]
    [Index(nameof(UserTokenTypeId))]
    [Index(nameof(IsExpired))]
    [Index(nameof(ExpiryDate))]
    [Index(nameof(IsConsumed))]
    [Index(nameof(ConsumedDate))]
    public class UserToken
    {
        [Column(ColumnNames.UserTokenId)]
        [MaxLength(ColumnConstraints.UserTokenIdMaxLength)]
        [Key]
        public byte[] UserTokenId { get; set; }

        [Column(ColumnNames.CreatedDate)]
        [Required]
        public DateTime CreatedDate { get; set; }

        [Column(ColumnNames.UserId)]
        [Required]
        public long UserId { get; set; }

        [Column(ColumnNames.UserTokenTypeId)]
        [Required]
        public long UserTokenTypeId { get; set; }

        [Column(ColumnNames.TokenSecretSalt)]
        [MaxLength(ColumnConstraints.TokenSecretSaltMaxLength)]
        [Required]
        public byte[] TokenSecretSalt { get; set; }

        [Column(ColumnNames.TokenSecretHash)]
        [MaxLength(ColumnConstraints.TokenSecretHashMaxLength)]
        [Required]
        public byte[] TokenSecretHash { get; set; }

        [Column(ColumnNames.IsExpired)]
        [Required]
        public bool IsExpired { get; set; }

        [Column(ColumnNames.ExpiryDate)]
        [Required]
        public DateTime ExpiryDate { get; set; }

        [Column(ColumnNames.IsConsumed)]
        [Required]
        public bool IsConsumed { get; set; }

        [Column(ColumnNames.ConsumedDate)]
        public DateTime? ConsumedDate { get; set; }
    }
}