using Microsoft.EntityFrameworkCore;
using Ribbons.Users.Definitions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users;

[Table(TableNames.UserGroupUser)]
[Index(nameof(UserGroupId))]
[Index(nameof(UserId))]
[Index(nameof(UserGroupId), nameof(UserId), IsUnique = true)]
public class TUserGroupUser
{
    [Column(ColumnNames.UserGroupUserId)]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long UserGroupUserId { get; set; }

    [Column(ColumnNames.UserGroupId)]
    [Required]
    public long UserGroupId { get; set; }

    [Column(ColumnNames.UserId)]
    [Required]
    public long UserId { get; set; }

    [Column(ColumnNames.CreatedDate)]
    [Required]
    public DateTime CreatedDate { get; set; }

    public virtual TUserGroup UserGroup { get; set; }
    public virtual TUser User { get; set; }
}