using System.Threading.Tasks;

namespace IShop.Common.Messaging.Command
{
    public interface ICommandDispatcher
    {
        Task DispatchAsync<TCommand>(TCommand command, ICorrelationContext context) 
            where TCommand : ICommand;
    }
}
