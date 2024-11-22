using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Ribbons.Messaging.Email
{
    public sealed class EmailMessageSender : MessageSender<EmailMessage>
    {
        private SmtpClient SmtpClient { get; set; }

        public EmailMessageSender(ILogger<EmailMessageSender> logger) : base(logger) { }

        public override async Task InitializeAsync()
        {
            SmtpClient = new SmtpClient();
        }

        public override async Task SendAsync(EmailMessage message)
        {
            
        }
    }
}