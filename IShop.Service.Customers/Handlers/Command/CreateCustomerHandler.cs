using IShop.Common.Messaging;
using IShop.Common.Messaging.Command;
using IShop.Service.Customers.Messages.Command;
using System;
using System.Threading.Tasks;

namespace IShop.Service.Customers.Handlers.Command
{
    public class CreateCustomerHandler : ICommandHandler<CreateCustomerCommand>
    {
        public Task HandleAsync(CreateCustomerCommand command, ICorrelationContext context)
        {
            throw new NotImplementedException();
        }
    }
}
