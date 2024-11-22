using System.Threading;
using System.Threading.Tasks;

namespace Ribbons.Messaging.Email
{
    public abstract class MessageSender<TMessage> : IMessageSender<TMessage>
    {
        public abstract Task SendAsync(TMessage message);
        public abstract Task StartAsync(CancellationToken cancellationToken);
        public abstract Task StopAsync(CancellationToken cancellationToken);
    }
}