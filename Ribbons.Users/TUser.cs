using Microsoft.EntityFrameworkCore;
using Ribbons.Users.Definitions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users;

[Table(TableNames.User)]
[Index(nameof(UserTypeId))]
[Index(nameof(UserName))]
[Index(nameof(UserTypeId), nameof(UserName), IsUnique = true)]
[Index(nameof(CreatedDate))]
[Index(nameof(ModifiedDate))]
[Index(nameof(UserStatusId))]
public class TUser
{
    [Column(ColumnNames.UserId)]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long UserId { get; set; }

    [Column(ColumnNames.UserTypeId)]
    [Required]
    public long UserTypeId { get; set; }

    [Column(ColumnNames.UserName)]
    [Required]
    [StringLength(DataConstraints.UserNameLength)]
    public string UserName { get; set; }

    [Column(ColumnNames.CreatedDate)]
    [Required]
    public DateTime CreatedDate { get; set; }

    [Column(ColumnNames.ModifiedDate)]
    [Required]
    public DateTime ModifiedDate { get; set; }

    [Column(ColumnNames.UserStatusId)]
    [Required]
    public long UserStatusId { get; set; }

    public virtual ICollection<TUserAttribute> UserAttributes { get; set; }
    public virtual TUserEmail UserEmail { get; set; }
    public virtual ICollection<TUserGroupUser> UserGroupUsers { get; set; }
    public virtual ICollection<TUserCredential> UserCredentials { get; set; }
    public virtual TUserPhone UserPhone { get; set; }
    public virtual ICollection<TUserSession> UserSessions { get; set; }
    public virtual TUserStatus UserStatus { get; set; }
    public virtual ICollection<TUserToken> UserTokens { get; set; }
    public virtual TUserType UserType { get; set; }
}