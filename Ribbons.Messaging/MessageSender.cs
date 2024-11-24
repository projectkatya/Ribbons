using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ribbons.Messaging
{
    public abstract class MessageSender<TMessage, TConfiguration> : IMessageSender<TMessage> where TConfiguration : MessageSenderConfig
    {
        protected ILogger Logger { get; }
        protected TConfiguration Configuration { get; }
        protected IMessageQueue<TMessage> Queue { get; }
        protected Dictionary<string, Task> ExecutionTasks { get; }

        protected MessageSender(ILogger logger, IOptions<TConfiguration> options, IMessageQueue<TMessage> queue)
        {
            Logger = logger;
            Configuration = options.Value;
            Queue = queue;
            ExecutionTasks = new();
        }

        public async Task SendAsync(TMessage message)
        {
            await Queue.EnqueueAsync(message);
        }

        protected async Task ExecuteAsync(string name, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {

            }

            await Task.CompletedTask;
        }

        public abstract Task StartAsync(CancellationToken cancellationToken);
        public abstract Task StopAsync(CancellationToken cancellationToken);
    }
}