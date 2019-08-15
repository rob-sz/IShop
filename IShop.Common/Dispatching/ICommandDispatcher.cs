using IShop.Common.Messaging;
using System.Threading.Tasks;

namespace IShop.Common.Dispatching
{
    public interface ICommandDispatcher<TSender> where TSender : class
    {
        Task DispatchAsync(ICommand command, IMessageCorrelationContext context);
    }
}
