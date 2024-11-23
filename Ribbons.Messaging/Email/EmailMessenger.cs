using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ribbons.Messaging.Email
{
    public class EmailMessenger : Messenger<EmailMessage>
    {
        public EmailMessenger(ILogger logger, IMessageSenderFactory<EmailMessage> senderFactory) : base(logger, senderFactory) { }

        public override Task SendAsync(EmailMessage message)
        {
            throw new NotImplementedException();
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}