using AutoMapper;
using CAT.Application.Abstractions.Messaging;
using CAT.Application.Contracts.Cats;
using CAT.Domain.Entities;
using CAT.Domain.Repository;

namespace CAT.Application.Core.Cats.Queries.GetCats
{
    internal sealed class GetCatsQueryHandler : IQueryHandler<GetCatsQuery, List<CatResponse>>
    {
        protected readonly IMapper _mapper;
        private readonly ICatRepository _catRepository;

        public GetCatsQueryHandler(IMapper mapper, ICatRepository catRepository)
        {
            _catRepository = catRepository;
            _mapper = mapper;
        }

        public async Task<List<CatResponse>> Handle(GetCatsQuery request, CancellationToken cancellationToken)
        {
            List<Cat> cats = await _catRepository.GetCats();

            return this._mapper.Map<List<CatResponse>>(cats);
        }
    }
}
