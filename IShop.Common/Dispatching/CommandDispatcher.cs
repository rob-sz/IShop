using IShop.Common.Messaging;
using System.Threading.Tasks;

namespace IShop.Common.Dispatching
{
    public class CommandDispatcher<TSender>
        : ICommandDispatcher<TSender> where TSender : class
    {
        private readonly IMessageBusClient messageBusClient;

        public CommandDispatcher(IMessageBusClient messageBusClient)
        {
            this.messageBusClient = messageBusClient;
        }

        public async Task DispatchAsync(ICommand command, IMessageCorrelationContext context)
            => await messageBusClient.SendAsync(command, context);
    }
}
