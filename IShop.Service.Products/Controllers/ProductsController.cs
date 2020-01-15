using System.Threading.Tasks;
using IShop.Common.Messaging.Query;
using IShop.Common.Mvc.Controllers;
using IShop.Service.Products.Messages.Query;
using Microsoft.AspNetCore.Mvc;

namespace IShop.Service.Products.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : BaseController
    {
        private readonly IQueryDispatcher queryDispatcher;

        public ProductsController(
            IQueryDispatcher queryDispatcher)
        {
            this.queryDispatcher = queryDispatcher;
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
                    null as GetProductCategoriesQuery));
    }
}
