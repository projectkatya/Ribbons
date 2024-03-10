using Microsoft.EntityFrameworkCore;
using Ribbons.Users.Definitions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users
{
    [Table(TableNames.UserToken)]
    [Index(nameof(UserId))]
    [Index(nameof(Type))]
    [Index(nameof(CreatedDate))]
    [Index(nameof(IsExpired))]
    [Index(nameof(ExpiryDate))]
    [Index(nameof(IsConsumed))]
    [Index(nameof(ConsumedDate))]
    public class UserToken
    {
        [Column(ColumnNames.UserTokenId)]
        [Key]
        [MaxLength(LengthConstraints.UserTokenIdLength)]
        public byte[] UserTokenId { get; set; }

        [Column(ColumnNames.UserId)]
        [Required]
        public long UserId { get; set; }

        [Column(ColumnNames.Type)]
        [Required]
        public UserTokenType Type { get; set; }

        [Column(ColumnNames.CreatedDate)]
        [Required]
        public DateTime CreatedDate { get; set; }

        [Column(ColumnNames.IsExpired)]
        [Required]
        public bool IsExpired { get; set; }

        [Column(ColumnNames.ExpiryDate)]
        [Required]
        public DateTime ExpiryDate { get; set; }

        [Column(ColumnNames.TokenSecretSalt)]
        [Required]
        [MaxLength(LengthConstraints.TokenSecretSaltLength)]
        public byte[] TokenSecretSalt { get; set; }

        [Column(ColumnNames.TokenSecretHash)]
        [Required]
        [MaxLength(LengthConstraints.TokenSecretHashLength)]
        public byte[] TokenSecretHash { get; set; }

        [Column(ColumnNames.IsConsumed)]
        [Required]
        public bool IsConsumed { get; set; }

        [Column(ColumnNames.ConsumedDate)]
        public DateTime? ConsumedDate { get; set; }

        public virtual User User { get; set; }
    }
}