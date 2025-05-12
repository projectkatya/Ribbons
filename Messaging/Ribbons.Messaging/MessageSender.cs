using System.Threading;
using System.Threading.Tasks;

namespace Ribbons.Messaging
{
	public abstract class MessageSender<TMessage> : IMessageSender<TMessage>
	{
		public async Task StartAsync(CancellationToken cancellationToken)
		{
			
		}

		public async Task StopAsync(CancellationToken cancellationToken)
		{
			
		}

		protected async Task ExecuteAsync(CancellationToken cancellationToken)
		{
		}
	}
}