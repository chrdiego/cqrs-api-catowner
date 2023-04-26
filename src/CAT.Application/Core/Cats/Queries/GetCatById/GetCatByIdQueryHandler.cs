using AutoMapper;
using CAT.Application.Abstractions.Messaging;
using CAT.Application.Contracts.Cats;
using CAT.Application.Exceptions;
using CAT.Domain.Entities;
using CAT.Domain.Repository;

namespace CAT.Application.Core.Cats.Queries.GetCatById
{
    internal sealed class GetCatByIdQueryHandler : IQueryHandler<GetCatByIdQuery, CatResponse>
    {
        protected readonly IMapper _mapper;
        private readonly ICatRepository _catRepository;

        public GetCatByIdQueryHandler(IMapper mapper, ICatRepository catRepository)
        {
            _catRepository = catRepository;
            _mapper = mapper;
        }

        public async Task<CatResponse> Handle(GetCatByIdQuery request, CancellationToken cancellationToken)
        {

            Cat cat = await _catRepository.GetCatById(request.Id);

            return this._mapper.Map<CatResponse>(cat);
        }
    }
}
