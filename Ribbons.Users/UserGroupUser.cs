using Microsoft.EntityFrameworkCore;
using Ribbons.Users.Definitions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users
{
    [Table(TableNames.UserGroupUser)]
    [PrimaryKey(nameof(UserGroupId), nameof(UserId))]
    [Index(nameof(UserId))]
    public class UserGroupUser
    {
        [Column(ColumnNames.UserGroupId)]
        public long UserGroupId { get; set; }

        [Column(ColumnNames.UserId)]
        public long UserId { get; set; }

        public virtual UserGroup UserGroup { get; set; }
        public virtual User User { get; set; }
    }
}