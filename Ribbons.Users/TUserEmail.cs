using Microsoft.EntityFrameworkCore;
using Ribbons.Users.Definitions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users;

[Table(TableNames.UserEmail)]
[Index(nameof(UserTypeId))]
[Index(nameof(EmailAddress))]
[Index(nameof(UserTypeId), nameof(EmailAddress), IsUnique = true)]
[Index(nameof(CreatedDate))]
[Index(nameof(ModifiedDate))]
[Index(nameof(IsVerified))]
[Index(nameof(VerifiedDate))]
public class TUserEmail
{
    [Column(ColumnNames.UserId)]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long UserId { get; set; }

    [Column(ColumnNames.UserTypeId)]
    [Required]
    public long UserTypeId { get; set; }

    [Column(ColumnNames.EmailAddress)]
    [Required]
    [StringLength(DataConstraints.EmailAddressLength)]
    public string EmailAddress { get; set; }

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
    public DateTime? VerifiedDate { get; set; }

    public virtual TUser User { get; set; }
    public virtual TUserType UserType { get; set; }
}