using System.Threading.Tasks;
using IShop.Common.Messaging.Command;
using IShop.Common.Messaging.Query;
using IShop.Common.Mvc.Controllers;
using IShop.Service.Customers.Domain.Model;
using IShop.Service.Customers.Messages.Command;
using IShop.Service.Customers.Messages.Query;
using Microsoft.AspNetCore.Mvc;

namespace IShop.Service.Customers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : BaseController
    {
        private readonly IQueryDispatcher queryDispatcher;
        private readonly ICommandDispatcher commandDispatcher;

        public CustomersController(
            IQueryDispatcher queryDispatcher,
            ICommandDispatcher commandDispatcher)
        {
            this.queryDispatcher = queryDispatcher;
            this.commandDispatcher = commandDispatcher;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] GetCustomerQuery query)
            => SingleResult(await queryDispatcher.DispatchAsync<Customer>(query));

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateCustomerCommand command)
        {
            await commandDispatcher.DispatchAsync(command, CommandContext);
            return AcceptedResult();
        }
    }
}
