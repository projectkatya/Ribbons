using System.Threading.Tasks;

namespace Ribbons.Messaging
{
	public interface IMessageQueue<TMessage>
	{
		Task<TMessage> GetMessageAsync();
	}
}