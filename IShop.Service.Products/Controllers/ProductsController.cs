using System.Threading.Tasks;
using IShop.Common.Messaging.Command;
using IShop.Common.Messaging.Query;
using IShop.Common.Mvc.Controllers;
using IShop.Service.Products.Messages.Command;
using IShop.Service.Products.Messages.Query;
using Microsoft.AspNetCore.Mvc;

namespace IShop.Service.Products.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : BaseController
    {
        private readonly IQueryDispatcher queryDispatcher;
        private readonly ICommandDispatcher commandDispatcher;

        public ProductsController(
            IQueryDispatcher queryDispatcher,
            ICommandDispatcher commandDispatcher)
        {
            this.queryDispatcher = queryDispatcher;
            this.commandDispatcher = commandDispatcher;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAsync([FromRoute] GetProductQuery query)
            => SingleResult(await queryDispatcher.DispatchAsync<GetProductResult>(query));

        [HttpGet()]
        public async Task<IActionResult> GetAsync([FromQuery] GetProductSearchQuery query)
            => SingleResult(await queryDispatcher.DispatchAsync<GetProductSearchResult>(query));

        [HttpGet("Categories")]
        public async Task<IActionResult> GetAsync()
            => SingleResult(await queryDispatcher.DispatchAsync<GetProductCategoriesResult>(
                    new GetProductCategoriesQuery()));

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateProductCommand command)
        {
            await commandDispatcher.DispatchAsync(command, CommandContext);
            return AcceptedResult();
        }
    }
}
