using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace Ribbons.Messaging
{
    public interface IMessageSender : IHostedService
    {
    }

    public interface IMessageSender<TMessage> : IMessageSender
    {
        Task SendAsync(TMessage message);
    }
}