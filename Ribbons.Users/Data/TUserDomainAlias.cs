using Microsoft.EntityFrameworkCore;
using Ribbons.Users.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users.Data
{
    [Table(TableNames.TUserDomainAlias)]
    [Index(nameof(Alias), IsUnique = true)]
    [Index(nameof(UserDomainId))]
    public class TUserDomainAlias
    {
        [Column(ColumnNames.UserDomainAliasId)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserDomainAliasId { get; set; }

        [Column(ColumnNames.Alias)]
        [Required]
        [StringLength(ColumnConstraints.AliasLength)]
        public string Alias { get; set; }

        [Column(ColumnNames.UserDomainId)]
        [Required]
        public long UserDomainId { get; set; }

        [Column(ColumnNames.CreatedDate)]
        [Required]
        public DateTime CreatedDate { get; set; }

        [Column(ColumnNames.ModifiedDate)]
        [Required]
        public DateTime ModifiedDate { get; set; }

        public virtual TUserDomain UserDomain { get; set; }
    }
}