using Microsoft.EntityFrameworkCore;
using Ribbons.Users.Definitions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users
{
    [Table(TableNames.UserGroup)]
    [Index(nameof(UserTypeId))]
    [Index(nameof(Code))]
    [Index(nameof(UserTypeId), nameof(Code), IsUnique = true)]
    [Index(nameof(CreatedDate))]
    [Index(nameof(ModifiedDate))]
    public class TUserGroup
    {
        [Column(ColumnNames.UserGroupId)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserGroupId { get; set; }

        [Column(ColumnNames.UserTypeId)]
        [Required]
        public long UserTypeId { get; set; }

        [Column(ColumnNames.Code)]
        [Required]
        [StringLength(DataConstraints.CodeMaxLength)]
        public string Code { get; set; }

        [Column(ColumnNames.Name)]
        [Required]
        [StringLength(DataConstraints.NameMaxLength)]
        public string Name { get; set; }

        [Column(ColumnNames.Description)]
        [StringLength(DataConstraints.DescriptionLength)]
        public string Description { get; set; }

        [Column(ColumnNames.CreatedDate)]
        [Required]
        public DateTime CreatedDate { get; set; }

        [Column(ColumnNames.ModifiedDate)]
        [Required]
        public DateTime ModifiedDate { get; set; }

        public virtual TUserType UserType { get; set; }
        public virtual ICollection<TUserGroupUser> UserGroupUsers { get; set; }
    }
}
