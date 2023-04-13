using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAT.Application.Abstractions.Messaging;
using CAT.Application.Contracts.Cats;

namespace CAT.Application.Core.Cats.Queries.GetCatById
{
    public sealed class GetCatByIdQuery : IQuery<CatResponse>
    {
        public GetCatByIdQuery(int catId) => Id = catId;

        public int Id { get; }
    }
}
