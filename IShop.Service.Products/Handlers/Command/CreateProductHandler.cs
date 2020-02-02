using IShop.Common.Messaging;
using IShop.Common.Messaging.Command;
using IShop.Service.Products.Messages.Command;
using IShop.Service.Products.Persistence;
using System.Threading.Tasks;

namespace IShop.Service.Products.Handlers.Command
{
    public class CreateProductHandler
        : ICommandHandler<CreateProductCommand>
    {
        private readonly IProductRepository repository;

        public CreateProductHandler(IProductRepository repository)
        {
            this.repository = repository;
        }

        public async Task HandleAsync(CreateProductCommand command, ICorrelationContext context)
        {
            await repository.CreateProductAsync(command.Product);
        }
    }
}
