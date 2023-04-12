using MediatR;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;

namespace CAT.Presentation.Infrastructure
{
    [Route("api/[controller]")]
    public class ApiBaseController : ControllerBase
    {
        protected ApiBaseController(ISender sender)
        {
            Sender = sender;
        }

        protected ISender Sender { get; }

        //protected IActionResult BadRequest(Error error) => BadRequest(new ApiErrorResponse(new[] { error }));

        //protected new IActionResult Ok(object value) => base.Ok(value);

        //protected new IActionResult NotFound() => NotFound("The requested resource was not found.");
    }
}
