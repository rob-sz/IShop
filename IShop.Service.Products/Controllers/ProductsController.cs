using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IShop.Common.Messaging.Query;
using IShop.Common.Mvc.Controllers;
using IShop.Service.Products.Domain.Model;
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

        [HttpGet("categories")]
        public async Task<IActionResult> GetAsync()
            => SingleResult(
                await queryDispatcher.DispatchAsync<IEnumerable<ProductCategory>>(
                    null as GetCategoriesQuery));

        [HttpGet()]
        public async Task<IActionResult> GetAsync([FromQuery] GetProductsByCategoryQuery query)
            => SingleResult(await queryDispatcher.DispatchAsync<IEnumerable<Product>>(query));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] GetProductQuery query)
            => SingleResult(await queryDispatcher.DispatchAsync<Product>(query));
    }
}
