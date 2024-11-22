using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Ribbons.Messaging.Email
{
    public sealed class EmailMessagingClient : MessagingClient<EmailMessage>
    {
        public EmailMessagingClient(ILogger<EmailMessagingClient> logger, IMessageSender<EmailMessage> sender) : base(logger, sender) { }

        public override Task SendAsync(EmailMessage message)
        {
            throw new System.NotImplementedException();
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            await Sender.InitializeAsync();
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}