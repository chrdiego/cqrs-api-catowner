using CAT.Application.Abstractions.Messaging;
using CAT.Application.Contracts.Cats;

namespace CAT.Application.Core.Cats.Queries.GetCats
{
    public sealed class GetCatsQuery : IQuery<List<CatResponse>>
    {
        public GetCatsQuery()
        {
        }
    }
}
