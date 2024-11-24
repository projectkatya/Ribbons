using System.Threading.Tasks;

namespace Ribbons.Messaging
{
    public interface IMessageQueue<TMessage>
    {
        Task EnqueueAsync(TMessage message);
        Task<TMessage> DequeueAsync();
    }
}