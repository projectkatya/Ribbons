using Microsoft.EntityFrameworkCore;
using Ribbons.Users.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users.Data
{
    [Table(TableNames.TUser)]
    [Index(nameof(UserDomainId))]
    [Index(nameof(UserName))]
    [Index(nameof(UserDomainId), nameof(UserName), IsUnique = true)]
    public class TUser
    {
        [Column(ColumnNames.UserId)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserId { get; set; }

        [Column(ColumnNames.UserDomainId)]
        [Required]
        public long UserDomainId { get; set; }

        [Column(ColumnNames.UserName)]
        [Required]
        [StringLength(ColumnConstraints.UserNameMaxLength)]
        public string UserName { get; set; }

        [Column(ColumnNames.CreatedDate)]
        [Required]
        public DateTime CreatedDate { get; set; }

        [Column(ColumnNames.ModifiedDate)]
        [Required]
        public DateTime ModifiedDate { get; set; }

        public virtual TUserDomain UserDomain { get; set; }
    }
}