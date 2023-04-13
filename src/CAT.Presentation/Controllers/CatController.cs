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
            return this.Ok(await this.Sender.Send(new GetCatsQuery()));
        }

        [HttpGet("GetCatById")]
        public async Task<IActionResult> GetCatById(int id)
        {
            return this.Ok(await this.Sender.Send(new GetCatByIdQuery(id)));
        }
    }
}
