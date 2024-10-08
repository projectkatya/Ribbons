﻿using Microsoft.EntityFrameworkCore;
using Ribbons.Users.Definitions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users
{
    [Table(TableNames.UserGroup)]
    [Index(nameof(CreatedDate))]
    [Index(nameof(ModifiedDate))]
    [Index(nameof(UserDomainId))]
    [Index(nameof(UserTypeId))]
    [Index(nameof(Code))]
    [Index(nameof(UserDomainId), nameof(UserTypeId), nameof(Code), IsUnique = true)]
    public class UserGroup
    {
        [Column(ColumnNames.UserGroupId)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserGroupId { get; set; }

        [Column(ColumnNames.CreatedDate)]
        [Required]
        public DateTime CreatedDate { get; set; }

        [Column(ColumnNames.ModifiedDate)]
        [Required]
        public DateTime ModifiedDate { get; set; }

        [Column(ColumnNames.UserDomainId)]
        [Required]
        public long UserDomainId { get; set; }

        [Column(ColumnNames.UserTypeId)]
        [Required]
        public long UserTypeId { get; set; }

        [Column(ColumnNames.Name)]
        [Required]
        public string Name { get; set; }

        [Column(ColumnNames.Code)]
        [Required]
        public string Code { get; set; }

        [Column(ColumnNames.Description)]
        public string Description { get; set; }
    }
}