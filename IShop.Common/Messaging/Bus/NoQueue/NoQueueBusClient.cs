using IShop.Common.Messaging.Command;
using IShop.Common.Messaging.Event;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace IShop.Common.Messaging.Bus.NoQueue
{
    public class NoQueueBusClient : IMessageBusClient
    {
        private readonly IServiceProvider serviceProvider;

        public NoQueueBusClient(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task PublishAsync<TEvent>(TEvent @event, ICorrelationContext context)
            where TEvent : IEvent
            => await serviceProvider.GetService<IEventHandler<TEvent>>().HandleAsync(@event, context);

        public async Task SendAsync<TCommand>(TCommand command, ICorrelationContext context)
            where TCommand : ICommand
            => await serviceProvider.GetService<ICommandHandler<TCommand>>().HandleAsync(command, context);
    }
}
