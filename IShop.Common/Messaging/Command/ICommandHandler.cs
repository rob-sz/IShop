using System.Threading.Tasks;

namespace IShop.Common.Messaging.Command
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command, ICorrelationContext context);
    }
}
