using System.Collections.Generic;

namespace Ribbons.Messaging.Email
{
	public sealed class EmailMessage
	{
		public EmailAddress From { get; set; }
		public List<EmailAddress> To { get; set; }
		public List<EmailAddress> Cc { get; set; }
		public List<EmailAddress> Bcc { get; set; }
		public string Subject { get; set; }
		public string Body { get; set; }
		public List<EmailAttachment> Attachments { get; set; }
	}
}