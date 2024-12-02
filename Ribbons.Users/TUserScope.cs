using Microsoft.EntityFrameworkCore;
using Ribbons.Users.Definitions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users
{
    [Table(TableNames.UserScope)]
    [Index(nameof(Code), IsUnique = true)]
    [Index(nameof(CreatedDate))]
    [Index(nameof(ModifiedDate))]
    public class TUserScope
    {
        [Column(ColumnNames.UserScopeId)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserScopeId { get; set; }

        [Column(ColumnNames.Code)]
        [Required]
        [StringLength(DataConstraints.CodeLength)]
        public string Code { get; set; }

        [Column(ColumnNames.Name)]
        [Required]
        [StringLength(DataConstraints.NameLength)]
        public string Name { get; set; }

        [Column(ColumnNames.Description)]
        [StringLength(DataConstraints.DescriptionLength)]
        public string Description { get; set; }

        [Column(ColumnNames.CreatedDate)]
        [Required]
        public DateTime CreatedDate { get; set; }

        [Column(ColumnNames.ModifiedDate)]
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<TUserType> UserTypes { get; set; }
        public virtual ICollection<TUserScopeIdentifier> UserScopeIdentifiers { get; set; }
    }
}