using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace Ribbons.Messaging
{
    public interface IMessageSender<TMessage> : IHostedService
    {
        Task SendAsync(TMessage message);
    }
}