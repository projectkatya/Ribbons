using System.Threading.Tasks;

namespace Ribbons.Messaging
{
    public interface IMessageSender<TMessage>
    {
        Task SendAsync(TMessage message);
        Task InitializeAsync();
    }
}