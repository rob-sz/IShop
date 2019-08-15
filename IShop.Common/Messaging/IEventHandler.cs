using System.Threading.Tasks;

namespace IShop.Common.Messaging
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        Task HandleAsync(TEvent @event, IMessageCorrelationContext context);
    }
}
