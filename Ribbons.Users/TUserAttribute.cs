using Microsoft.EntityFrameworkCore;
using Ribbons.Users.Definitions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users;

[Table(TableNames.UserAttribute)]
[Index(nameof(UserId))]
[Index(nameof(UserAttributeTypeId))]
public class TUserAttribute
{
    [Column(ColumnNames.UserAttributeId)]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long UserAttributeId { get; set; }

    [Column(ColumnNames.UserId)]
    [Required]
    public long UserId { get; set; }

    [Column(ColumnNames.UserAttributeTypeId)]
    [Required]
    public long UserAttributeTypeId { get; set; }

    [Column(ColumnNames.StringValue)]
    public string StringValue { get; set; }

    [Column(ColumnNames.Int16Value)]
    public short? Int16Value { get; set; }

    [Column(ColumnNames.Int32Value)]
    public int? Int32Value { get; set; }

    [Column(ColumnNames.Int64Value)]
    public long? Int64Value { get; set; }

    [Column(ColumnNames.FloatValue)]
    public float? FloatValue { get; set; }

    [Column(ColumnNames.DecimalValue)]
    [Precision(20, 2)]
    public decimal? DecimalValue { get; set; }

    [Column(ColumnNames.DoubleValue)]
    public double? DoubleValue { get; set; }

    [Column(ColumnNames.DateTimeValue)]
    public DateTime? DateTimeValue { get; set; }

    [Column(ColumnNames.BooleanValue)]
    public bool? BooleanValue { get; set; }

    public virtual TUser User { get; set; }
    public virtual TUserAttributeType UserAttributeType { get; set; }
}