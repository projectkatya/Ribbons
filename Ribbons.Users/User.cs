using Microsoft.EntityFrameworkCore;
using Ribbons.Users.Definitions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users
{
    [Table(TableNames.User)]
    [Index(nameof(UserTypeId))]
    [Index(nameof(Status))]
    [Index(nameof(CreatedDate))]
    [Index(nameof(ModifiedDate))]
    [Index(nameof(UserName))]
    [Index(nameof(UserTypeId), nameof(UserName), IsUnique = true)]
    public class User
    {
        [Column(ColumnNames.UserId)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserId { get; set; }

        [Column(ColumnNames.UserTypeId)]
        [Required]
        public int UserTypeId { get; set; }

        [Column(ColumnNames.Status)]
        [Required]
        public UserStatus Status { get; set; }

        [Column(ColumnNames.CreatedDate)]
        [Required]
        public DateTime CreatedDate { get; set; }

        [Column(ColumnNames.ModifiedDate)]
        public DateTime ModifiedDate { get; set; }

        [Column(ColumnNames.UserName)]
        [Required]
        [StringLength(LengthConstraints.UserNameLength)]
        public string UserName { get; set; }

        [Column(ColumnNames.FirstName)]
        [StringLength(LengthConstraints.FirstNameLength)]
        public string FirstName { get; set; }

        [Column(ColumnNames.LastName)]
        [StringLength(LengthConstraints.LastNameLength)]
        public string LastName { get; set; }

        public virtual UserEmail UserEmail { get; set; }
        public virtual UserPassword UserPassword { get; set; }
        public virtual UserPhone UserPhone { get; set; }
        public virtual ICollection<UserSession> UserSessions { get; set; }
        public virtual ICollection<UserToken> UserTokens { get; set; }
        public virtual UserType UserType { get; set; }
    }
}