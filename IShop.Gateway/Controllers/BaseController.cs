using Microsoft.AspNetCore.Mvc;

namespace IShop.Gateway.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IActionResult SingleResult<T>(T result)
        {
            if (result != null)
                return Ok(result);

            return NotFound();
        }

        protected IActionResult AcceptedResult()
        {
            return Accepted();
        }

        protected IActionResult AcceptedResult<T>(T result)
        {
            return Accepted(result);
        }
    }
}
