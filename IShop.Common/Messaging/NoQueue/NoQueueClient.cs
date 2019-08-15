using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace IShop.Common.Messaging.NoQueue
{
    public class NoQueueClient : IMessageBusClient
    {
        private readonly IServiceProvider serviceProvider;

        public NoQueueClient(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task PublishAsync<TEvent>(TEvent @event, IMessageCorrelationContext context)
            where TEvent : IEvent
            => await serviceProvider.GetService<IEventHandler<TEvent>>().HandleAsync(@event, context);

        public async Task SendAsync<TCommand>(TCommand command, IMessageCorrelationContext context)
            where TCommand : ICommand
            => await serviceProvider.GetService<ICommandHandler<TCommand>>().HandleAsync(command, context);
    }
}
