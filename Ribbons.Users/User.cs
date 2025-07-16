using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ribbons.Users;

[Table(TableNames.User)]
public class User
{
	public long UserId { get; set; }
	public DateTime CreatedDate { get; set; }
	public string UserName { get; set; }
}