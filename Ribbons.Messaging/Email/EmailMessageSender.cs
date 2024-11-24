using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ribbons.Messaging.Email
{
    public sealed class EmailMessageSender : MessageSender<EmailMessage, EmailMessageSenderConfig>
    {
        public EmailMessageSender(ILogger logger, IOptions<EmailMessageSenderConfig> options, IMessageQueue<EmailMessage> queue) : base(logger, options, queue) { }

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