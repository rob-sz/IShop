using System.Threading.Tasks;

namespace IShop.Common.Dispatching
{
    public interface ICommandDispatcher<TSender> where TSender : class
    {
        //Task<TCommand> Dispatch<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
