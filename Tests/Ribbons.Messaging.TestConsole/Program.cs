using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Ribbons.Messaging.Email;

namespace Ribbons.Messaging.TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ILoggerFactory loggerFactory = NullLoggerFactory.Instance;
            EmailMessageSender sender = new(loggerFactory.CreateLogger<EmailMessageSender>());
            EmailMessagingClient client = new(loggerFactory.CreateLogger<EmailMessagingClient>(), sender);
        }
    }
}
