using System.Collections.Generic;

namespace Ribbons.Messaging.Email
{
	public sealed class EmailAddress
	{
		public string Name { get; set; }
		public string Address { get; set; }
		public Dictionary<string, string> Metadata { get; set; }
	}
}