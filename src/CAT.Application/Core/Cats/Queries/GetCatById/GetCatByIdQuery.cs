using CAT.Application.Abstractions.Messaging;
using CAT.Application.Contracts.Cats;
using CAT.Application.Contracts.Result;

namespace CAT.Application.Core.Cats.Queries.GetCatById
{
    public sealed class GetCatByIdQuery : IQuery<Result<CatResponse>>
    {
        public GetCatByIdQuery(int catId)
        {
            Id = catId;
        }

        public int Id { get; }
    }
}
