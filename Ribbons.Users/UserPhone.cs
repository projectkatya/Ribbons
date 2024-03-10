using Microsoft.EntityFrameworkCore;
using Ribbons.Users.Definitions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users
{
    [Table(TableNames.UserPhone)]
    [Index(nameof(UserTypeId))]
    [Index(nameof(CreatedDate))]
    [Index(nameof(ModifiedDate))]
    [Index(nameof(PhoneNumber))]
    [Index(nameof(IsVerified))]
    [Index(nameof(VerifiedDate))]
    [Index(nameof(UserTypeId), nameof(PhoneNumber), IsUnique = true)]
    public class UserPhone
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

        [Column(ColumnNames.PhoneNumber)]
        [Required]
        [StringLength(LengthConstraints.PhoneNumberLength)]
        public string PhoneNumber { get; set; }

        [Column(ColumnNames.IsVerified)]
        [Required]
        public bool IsVerified { get; set; }

        [Column(ColumnNames.VerifiedDate)]
        public DateTime? VerifiedDate { get; set; }

        public virtual User User { get; set; }
    }
}