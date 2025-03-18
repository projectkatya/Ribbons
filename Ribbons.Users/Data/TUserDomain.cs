using Microsoft.EntityFrameworkCore;
using Ribbons.Users.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users.Data
{
    [Table(TableNames.TUserDomain)]
    [Index(nameof(Name), IsUnique = true)]
    public class TUserDomain
    {
        [Column(ColumnNames.UserDomainId)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserDomainId { get; set; }

        [Column(ColumnNames.Name)]
        [Required]
        [StringLength(ColumnConstraints.NameMaxLength)]
        public string Name { get; set; }

        [Column(ColumnNames.DisplayName)]
        [Required]
        [StringLength(ColumnConstraints.DisplayNameMaxLength)]
        public string DisplayName { get; set; }

        [Column(ColumnNames.CreatedDate)]
        [Required]
        public DateTime CreatedDate { get; set; }

        [Column(ColumnNames.ModifiedDate)]
        [Required]
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<TUser> Users { get; set; }
        public virtual ICollection<TUserDomainAlias> UserDomainAliases { get; set; }
    }
}
