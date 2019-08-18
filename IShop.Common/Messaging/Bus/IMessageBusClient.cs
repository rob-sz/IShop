using IShop.Common.Messaging.Command;
using IShop.Common.Messaging.Event;
using System.Threading.Tasks;

namespace IShop.Common.Messaging.Bus
{
    public interface IMessageBusClient
    {
        Task PublishAsync<TEvent>(TEvent @event, ICorrelationContext context)
            where TEvent : IEvent;
        Task SendAsync<TCommand>(TCommand command, ICorrelationContext context)
            where TCommand : ICommand;
    }
}
