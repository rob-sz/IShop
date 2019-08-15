using System;
using System.Threading.Tasks;
using IShop.Common.Dispatching;
using IShop.Gateway.Services.Customer.Model;
using Microsoft.AspNetCore.Mvc;

namespace IShop.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : BaseController
    {
        private readonly IQueryDispatcher<CustomersController> queryDispatcher;
        private readonly ICommandDispatcher<CustomersController> commandDispatcher;

        public CustomersController(IQueryDispatcher<CustomersController> queryDispatcher)
        {
            this.queryDispatcher = queryDispatcher;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
            => SingleResult(await queryDispatcher.DispatchAsync<Customer>("{id}", new { id }));

        // can the noqueue be done from here?
        // should this be an API call and the queueing done at the microservice level?
        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] string value)
        //    => AcceptedResult(await commandDispatcher.DispatchAsync()
        //}
    }
}
