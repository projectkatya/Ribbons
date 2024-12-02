using Ribbons.Users.Definitions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users
{
    [Table(TableNames.UserScopeIdentifier)]
    public class TUserScopeIdentifier
    {
        [Column(ColumnNames.UserScopeIdentifierId)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserScopeIdentifierId { get; set; }

        [Column(ColumnNames.UserScopeId)]
        [Required]
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
        [Required]
        public DateTime ModifiedDate { get; set; }

        public virtual TUserScope UserScope { get; set; }
    }
}