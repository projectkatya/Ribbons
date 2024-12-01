using Microsoft.EntityFrameworkCore;
using Ribbons.Users.Definitions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users
{
    [Table(TableNames.UserGroupUser)]
    [PrimaryKey(nameof(UserGroupId), nameof(UserId))]
    [Index(nameof(UserId))]
    public class TUserGroupUser
    {
        [Column(ColumnNames.UserGroupId)]
        public long UserGroupId { get; set; }

        [Column(ColumnNames.UserId)]
        public long UserId { get; set; }

        public virtual TUserGroup UserGroup { get; set; }
        public virtual TUser User { get; set; }
    }
}