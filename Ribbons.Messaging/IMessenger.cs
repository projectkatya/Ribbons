using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace Ribbons.Messaging
{
    public interface IMessenger<TMessage> : IHostedService
    {
        Task SendAsync(TMessage message);
    }
}