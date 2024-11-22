using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Ribbons.Messaging
{
    public abstract class MessageSender<TMessage> : IMessageSender<TMessage>
    {
        protected ILogger Logger { get; }

        protected MessageSender(ILogger logger)
        {
            Logger = logger;
        }

        public abstract Task SendAsync(TMessage message);
        public abstract Task InitializeAsync();
    }
}