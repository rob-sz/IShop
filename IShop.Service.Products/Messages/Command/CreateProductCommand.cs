using IShop.Common.Messaging.Command;
using IShop.Service.Products.Domain.Model;

namespace IShop.Service.Products.Messages.Command
{
    public class CreateProductCommand : ICommand
    {
        public Product Product { get; set; }
    }
}
