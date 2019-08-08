using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IShop.Service.Customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : BaseController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => SingleResult(await queryDispatcher.Dispatch<Customer>("{id}", id));
    }
}
