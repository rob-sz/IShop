using System.Threading.Tasks;

namespace IShop.Common.Messaging.Event
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        Task HandleAsync(TEvent @event, ICorrelationContext context);
    }
}
