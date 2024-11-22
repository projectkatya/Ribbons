using System.Threading;
using System.Threading.Tasks;

namespace Ribbons.Messaging.Email
{
    public sealed class EmailMessageSender : MessageSender<EmailMessage>
    {
        public override Task SendAsync(EmailMessage message)
        {
            throw new System.NotImplementedException();
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}