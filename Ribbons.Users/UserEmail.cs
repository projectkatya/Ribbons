using Microsoft.EntityFrameworkCore;
using Ribbons.Users.Definitions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users
{
    [Table(TableNames.UserEmail)]
    [Index(nameof(UserTypeId))]
    [Index(nameof(CreatedDate))]
    [Index(nameof(ModifiedDate))]
    [Index(nameof(EmailAddress))]
    [Index(nameof(IsVerified))]
    [Index(nameof(VerifiedDate))]
    [Index(nameof(UserTypeId), nameof(EmailAddress), IsUnique = true)]
    public class UserEmail
    {
        [Column(ColumnNames.UserId)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long UserId { get; set; }

        [Column(ColumnNames.UserTypeId)]
        [Required]
        public int UserTypeId { get; set; }

        [Column(ColumnNames.CreatedDate)]
        [Required]
        public DateTime CreatedDate { get; set; }

        [Column(ColumnNames.ModifiedDate)]
        [Required]
        public DateTime ModifiedDate { get; set; }

        [Column(ColumnNames.EmailAddress)]
        [Required]
        [StringLength(LengthConstraints.EmailAddressLength)]
        public string EmailAddress { get; set; }

        [Column(ColumnNames.IsVerified)]
        [Required]
        public bool IsVerified { get; set; }

        [Column(ColumnNames.VerifiedDate)]
        public DateTime? VerifiedDate { get; set; }

        public virtual User User { get; set; }
        public virtual UserType UserType { get; set; }
    }
}