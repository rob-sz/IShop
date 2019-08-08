using Microsoft.AspNetCore.Mvc;

namespace IShop.Service.Customer.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IActionResult SingleResult<T>(T model)
        {
            if (model != null)
                return Ok(model);

            return NotFound();
        }

        protected IActionResult AcceptedResult<T>(T context)
        {
            return Accepted(context);
        }
    }
}
