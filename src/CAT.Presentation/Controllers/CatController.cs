using CAT.Application.Contracts.Cats;
using CAT.Application.Core.Cats.Queries.GetCatById;
using CAT.Application.Core.Cats.Queries.GetCats;
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

        [HttpGet("GetCats")]
        public async Task<IActionResult> GetCats()
        {
            var result = await this.Sender.Send(new GetCatsQuery());

            return this.Ok(result);
        }

        [HttpGet("GetCatById")]
        public async Task<IActionResult> GetCatById(int id)
        {
            var result = await this.Sender.Send(new GetCatByIdQuery(id));

            return this.Ok(result);
        }
    }
}
