using CAT.Presentation.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CAT.Presentation.Controllers
{
    public class CatController : ApiBaseController
    {
        public CatController(ISender sender) : base(sender)
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            //this.Sender.Send();
            return this.Ok();
        }
    }
}
