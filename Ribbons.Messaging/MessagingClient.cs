using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Ribbons.Messaging
{
    public abstract class MessagingClient<TMessage> : IMessagingClient<TMessage>
    {
        protected ILogger Logger { get; }
        protected IMessageSender<TMessage> Sender { get; }

        protected MessagingClient(ILogger logger, IMessageSender<TMessage> sender)
        {
            Sender = sender;
        }

        public abstract Task SendAsync(TMessage message);
        public abstract Task StartAsync(CancellationToken cancellationToken);
        public abstract Task StopAsync(CancellationToken cancellationToken);
    }
}