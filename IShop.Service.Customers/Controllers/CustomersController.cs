using System;
using System.Threading.Tasks;
using IShop.Common.Dispatching;
using IShop.Service.Customers.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace IShop.Service.Customers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : BaseController
    {
        private IRequestDelegator requestDelegator;

        public CustomersController(IRequestDelegator requestDelegator)
        {
            this.requestDelegator = requestDelegator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => SingleResult(await requestDelegator.Delegate<Guid, Customer>(id));
    }
}
