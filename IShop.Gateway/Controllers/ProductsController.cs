using System;
using System.Threading.Tasks;
using IShop.Common.Messaging;
using IShop.Gateway.Services.Product.Model;
using IShop.Gateway.Services.Product.Query;
using Microsoft.AspNetCore.Mvc;

namespace IShop.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        private readonly IServiceBroker<ProductsController> serviceBroker;

        public ProductsController(IServiceBroker<ProductsController> serviceBroker)
        {
            this.serviceBroker = serviceBroker;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
            => SingleResult(await serviceBroker.ReceiveAsync<GetProductResult>("{0}", id));

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Product entity)
        {
            await serviceBroker.SendAsync(string.Empty, entity);
            return AcceptedResult();
        }
    }
}
