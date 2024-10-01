using Ribbons.Users.Definitions;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users
{
    [Table(TableNames.UserToken)]
    public class UserToken
    {
        [Column(ColumnNames.UserTokenId)]
        public byte[] UserTokenId { get; set; }

        [Column(ColumnNames.CreatedDate)]
        public DateTime CreatedDate { get; set; }

        [Column(ColumnNames.UserId)]
        public long UserId { get; set; }

        [Column(ColumnNames.TokenSecretSalt)]
        public byte[] TokenSecretSalt { get; set; }

        [Column(ColumnNames.TokenSecretHash)]
        public byte[] TokenSecretHash { get; set; }

        [Column(ColumnNames.IsExpired)]
        public bool IsExpired { get; set; }

        [Column(ColumnNames.ExpiryDate)]
        public DateTime? ExpiryDate { get; set; }

        [Column(ColumnNames.IsConsumed)]
        public bool IsConsumed { get; set; }

        [Column(ColumnNames.ConsumedDate)]
        public DateTime? ConsumedDate { get; set; }
    }
}