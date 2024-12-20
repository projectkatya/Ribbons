﻿using Microsoft.EntityFrameworkCore;
using Ribbons.Users.Definitions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users;

[Table(TableNames.UserSession)]
[Index(nameof(UserId))]
[Index(nameof(CreatedDate))]
[Index(nameof(IsExpired))]
[Index(nameof(ExpiryDate))]
public class TUserSession
{
    [Column(ColumnNames.UserSessionId)]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [MaxLength(DataConstraints.UserSessionIdLength)]
    public byte[] UserSessionId { get; set; }

    [Column(ColumnNames.UserId)]
    [Required]
    public long UserId { get; set; }

    [Column(ColumnNames.SessionSecretSalt)]
    [Required]
    [MaxLength(DataConstraints.SessionSecretSaltLength)]
    public byte[] SessionSecretSalt { get; set; }

    [Column(ColumnNames.SessionSecretHash)]
    [Required]
    [MaxLength(DataConstraints.SessionSecretHashLength)]
    public byte[] SessionSecretHash { get; set; }

    [Column(ColumnNames.CreatedDate)]
    [Required]
    public DateTime CreatedDate { get; set; }

    [Column(ColumnNames.IsExpired)]
    [Required]
    public bool IsExpired { get; set; }

    [Column(ColumnNames.ExpiryDate)]
    public DateTime? ExpiryDate { get; set; }

    public virtual TUser User { get; set; }
}