using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Ribbons.Messaging
{
    public abstract class Messenger<TMessage> : IMessenger<TMessage>
    {
        protected ILogger Logger { get; }
        protected IMessageSenderFactory<TMessage> SenderFactory { get; }
        protected ConcurrentDictionary<int, IMessageSender<TMessage>> Senders { get; }

        protected Messenger(ILogger logger, IMessageSenderFactory<TMessage> senderFactory)
        {
            Logger = logger;
            SenderFactory = senderFactory;
        }

        public abstract Task SendAsync(TMessage message);
        public abstract Task StartAsync(CancellationToken cancellationToken);
        public abstract Task StopAsync(CancellationToken cancellationToken);
    }
}