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

        public CustomersController(IQueryDispatcher<CustomersController> queryDispatcher)
        {
            this.queryDispatcher = queryDispatcher;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
            => SingleResult(await queryDispatcher.DispatchAsync<Customer>("{id}", new { id }));

        // POST api/values
        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] string value)
        //    => AcceptedResult(await dispatcher.PostAsync());
        //}
    }
}
