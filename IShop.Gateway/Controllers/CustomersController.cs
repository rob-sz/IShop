using System;
using System.Threading.Tasks;
using IShop.Common.Messaging;
using IShop.Gateway.Services.Customer.Model;
using Microsoft.AspNetCore.Mvc;

namespace IShop.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : BaseController
    {
        private readonly IServiceBroker<CustomersController> serviceBroker;

        public CustomersController(IServiceBroker<CustomersController> serviceBroker)
        {
            this.serviceBroker = serviceBroker;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
            => SingleResult(await serviceBroker.ReceiveAsync<Customer>("{id}", new { id }));

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Customer customer)
        {
            await serviceBroker.SendAsync(string.Empty, customer);
            return AcceptedResult();
        }
    }
}
