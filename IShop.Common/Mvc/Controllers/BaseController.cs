using IShop.Common.Messaging;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IShop.Common.Mvc.Controllers
{
    public class BaseController : ControllerBase
    {
        protected ICorrelationContext CommandContext
        {
            get
            {
                return new CorrelationContext
                {
                    CorrelationId = Guid.NewGuid(),
                    CorrelationDate = DateTime.UtcNow,
                    TraceIdentifier = HttpContext.TraceIdentifier,
                    ResourcePath = Request.Path.ToString()
                };
            }
        }

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
