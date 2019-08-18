using System.Threading.Tasks;

namespace IShop.Common.Messaging.Command
{
    public interface ICommandDispatcher
    {
        Task DispatchAsync(ICommand command, ICorrelationContext context);
    }
}
