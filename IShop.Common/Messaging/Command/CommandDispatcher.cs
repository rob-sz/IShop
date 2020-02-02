using IShop.Common.Messaging.Bus;
using System.Threading.Tasks;

namespace IShop.Common.Messaging.Command
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IMessageBusClient messageBusClient;

        public CommandDispatcher(IMessageBusClient messageBusClient)
        {
            this.messageBusClient = messageBusClient;
        }

        public async Task DispatchAsync<TCommand>(TCommand command, ICorrelationContext context)
            where TCommand : ICommand
        {
            await messageBusClient.SendAsync(command, context);
        }
    }
}
