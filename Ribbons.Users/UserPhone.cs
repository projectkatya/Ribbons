using Ribbons.Users.Definitions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users
{
    [Table(TableNames.UserPhone)]
    public class UserPhone
    {
        [Column(ColumnNames.UserId)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long UserId { get; set; }

        [Column(ColumnNames.UserTypeId)]
        [Required]
        public long UserTypeId { get; set; }

        [Column(ColumnNames.PhoneNumber)]
        [Required]
        [StringLength(ColumnConstraints.PhoneNumberLength)]
        public string PhoneNumber { get; set; }

        [Column(ColumnNames.CreatedDate)]
        [Required]
        public DateTime CreatedDate { get; set; }

        [Column(ColumnNames.ModifiedDate)]
        [Required]
        public DateTime ModifiedDate { get; set; }

        [Column(ColumnNames.IsVerified)]
        [Required]
        public bool IsVerified { get; set; }

        [Column(ColumnNames.VerifiedDate)]
        [Required]
        public DateTime? VerifiedDate { get; set; }

        public virtual User User { get; set; }
    }
}