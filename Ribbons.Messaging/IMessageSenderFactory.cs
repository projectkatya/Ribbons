namespace Ribbons.Messaging
{
    public interface IMessageSenderFactory<TMessage>
    {
        IMessageSender<TMessage> Build();
    }
}