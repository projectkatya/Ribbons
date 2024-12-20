﻿using Microsoft.EntityFrameworkCore;
using Ribbons.Users.Definitions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users;

[Table(TableNames.UserAttributeType)]
[Index(nameof(UserTypeId))]
[Index(nameof(Code))]
[Index(nameof(UserTypeId), nameof(Code), IsUnique = true)]
[Index(nameof(ValueType))]
[Index(nameof(CreatedDate))]
[Index(nameof(ModifiedDate))]
public class TUserAttributeType
{
    [Column(ColumnNames.UserAttributeTypeId)]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long UserAttributeTypeId { get; set; }

    [Column(ColumnNames.UserTypeId)]
    [Required]
    public long UserTypeId { get; set; }

    [Column(ColumnNames.Code)]
    [StringLength(DataConstraints.CodeMaxLength)]
    [Required]
    public string Code { get; set; }

    [Column(ColumnNames.Name)]
    [StringLength(DataConstraints.NameMaxLength)]
    [Required]
    public string Name { get; set; }

    [Column(ColumnNames.Description)]
    [StringLength(DataConstraints.DescriptionLength)]
    public string Description { get; set; }

    [Column(ColumnNames.ValueType, TypeName = "int")]
    [Required]
    public UserAttributeValueType ValueType { get; set; }

    [Column(ColumnNames.CreatedDate)]
    [Required]
    public DateTime CreatedDate { get; set; }

    [Column(ColumnNames.ModifiedDate)]
    [Required]
    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<TUserAttribute> UserAttributes { get; set; }
    public virtual TUserType UserType { get; set; }
}