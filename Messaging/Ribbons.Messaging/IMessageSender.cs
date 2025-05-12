using Microsoft.Extensions.Hosting;

namespace Ribbons.Messaging
{
	public interface IMessageSender<TMessage> : IHostedService
	{
	}
}