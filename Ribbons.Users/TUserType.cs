using Microsoft.EntityFrameworkCore;
using Ribbons.Users.Definitions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users
{
    [Table(TableNames.UserType)]
    [Index(nameof(UserScopeId))]
    [Index(nameof(Code))]
    [Index(nameof(UserScopeId), nameof(Code), IsUnique = true)]
    [Index(nameof(CreatedDate))]
    [Index(nameof(ModifiedDate))]
    public class TUserType
    {
        [Column(ColumnNames.UserTypeId)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserTypeId { get; set; }

        [Column(ColumnNames.UserScopeId)]
        [Required]
        public long UserScopeId { get; set; }

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

        public virtual ICollection<TUser> Users { get; set; }
        public virtual ICollection<TUserAttributeType> UserAttributeTypes { get; set; }
        public virtual ICollection<TUserCredentialType> UserCredentialTypes { get; set; }
        public virtual ICollection<TUserEmail> UserEmails { get; set; }
        public virtual ICollection<TUserGroup> UserGroups { get; set; }
        public virtual ICollection<TUserPhone> UserPhones { get; set; }
        public virtual TUserScope UserScope { get; set; }
        public virtual ICollection<TUserStatus> UserStatuses { get; set; }
        public virtual ICollection<TUserTokenType> UserTokenTypes { get; set; }
    }
}