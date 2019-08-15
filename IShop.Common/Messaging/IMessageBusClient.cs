using System.Threading.Tasks;

namespace IShop.Common.Messaging
{
    public interface IMessageBusClient
    {
        Task PublishAsync<TEvent>(TEvent @event, IMessageCorrelationContext context)
            where TEvent : IEvent;
        Task SendAsync<TCommand>(TCommand command, IMessageCorrelationContext context)
            where TCommand : ICommand;
    }
}
