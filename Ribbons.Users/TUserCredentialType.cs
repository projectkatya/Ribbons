using Microsoft.EntityFrameworkCore;
using Ribbons.Users.Definitions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users
{
    [Table(TableNames.UserCredentialType)]
    [Index(nameof(UserTypeId))]
    [Index(nameof(Code))]
    [Index(nameof(UserTypeId), nameof(Code), IsUnique = true)]
    [Index(nameof(CreatedDate))]
    [Index(nameof(ModifiedDate))]
    public class TUserCredentialType
    {
        [Column(ColumnNames.UserCredentialTypeId)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserCredentialTypeId { get; set; }

        [Column(ColumnNames.UserTypeId)]
        [Required]
        public long UserTypeId { get; set; }

        [Column(ColumnNames.Code)]
        [StringLength(DataConstraints.CodeLength)]
        [Required]
        public string Code { get; set; }

        [Column(ColumnNames.Name)]
        [StringLength(DataConstraints.NameLength)]
        [Required]
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

        public virtual ICollection<TUserCredential> UserCredentials { get; set; }
        public virtual TUserType UserType { get; set; }
    }
}
