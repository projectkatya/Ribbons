using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace Ribbons.Messaging
{
    public interface IMessagingClient<TMessage> : IHostedService
    {
        Task SendAsync(TMessage message);
    }
}