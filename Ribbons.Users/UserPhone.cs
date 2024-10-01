using Microsoft.EntityFrameworkCore;
using Ribbons.Users.Definitions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users
{
    [Table(TableNames.UserPhone)]
    [Index(nameof(CreatedDate))]
    [Index(nameof(ModifiedDate))]
    [Index(nameof(UserDomainId))]
    [Index(nameof(UserTypeId))]
    [Index(nameof(PhoneNumber))]
    [Index(nameof(UserDomainId), nameof(UserTypeId), nameof(PhoneNumber), IsUnique = true)]
    [Index(nameof(IsVerified))]
    [Index(nameof(VerifiedDate))]
    public class UserPhone
    {
        [Column(ColumnNames.UserId)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long UserId { get; set; }

        [Column(ColumnNames.CreatedDate)]
        [Required]
        public DateTime CreatedDate { get; set; }

        [Column(ColumnNames.ModifiedDate)]
        [Required]
        public DateTime ModifiedDate { get; set; }

        [Column(ColumnNames.UserDomainId)]
        [Required]
        public long UserDomainId { get; set; }

        [Column(ColumnNames.UserTypeId)]
        [Required]
        public long UserTypeId { get; set; }

        [Column(ColumnNames.PhoneNumber)]
        [StringLength(ColumnConstraints.PhoneNumberMaxLength)]
        [Required]
        public string PhoneNumber { get; set; }

        [Column(ColumnNames.IsVerified)]
        [Required]
        public bool IsVerified { get; set; }

        [Column(ColumnNames.VerifiedDate)]
        public DateTime? VerifiedDate { get; set; }
    }
}