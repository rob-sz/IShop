using System.Threading.Tasks;

namespace IShop.Common.Messaging
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand @event, IMessageCorrelationContext context);
    }
}
