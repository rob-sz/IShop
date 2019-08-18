using IShop.Common.Messaging;
using IShop.Common.Messaging.Command;
using IShop.Service.Customers.Domain;
using IShop.Service.Customers.Domain.Model;
using IShop.Service.Customers.Messages.Command;
using System.Threading.Tasks;

namespace IShop.Service.Customers.Handlers.Command
{
    public class CreateCustomerHandler : ICommandHandler<CreateCustomerCommand>
    {
        private readonly ICustomerService customerService;

        public CreateCustomerHandler(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public async Task HandleAsync(CreateCustomerCommand command, ICorrelationContext context)
        {
            var customer = new Customer
            {
                Id = command.Id,
                Email = command.Email,
                FirstName = command.FirstName,
                LastName = command.LastName
            };

            await customerService.CreateCustomerAsync(customer);
        }
    }
}
