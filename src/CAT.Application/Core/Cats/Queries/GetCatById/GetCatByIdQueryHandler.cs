using AutoMapper;
using CAT.Application.Abstractions.Messaging;
using CAT.Application.Contracts.Cats;
using CAT.Application.Contracts.Result;
using CAT.Application.Exceptions;
using CAT.Domain.Entities;
using CAT.Domain.Repository;
using FluentValidation.Results;

namespace CAT.Application.Core.Cats.Queries.GetCatById
{
    internal sealed class GetCatByIdQueryHandler : IQueryHandler<GetCatByIdQuery, Result<CatResponse>>
    {
        protected readonly IMapper _mapper;
        private readonly ICatRepository _catRepository;

        public GetCatByIdQueryHandler(IMapper mapper, ICatRepository catRepository)
        {
            _catRepository = catRepository;
            _mapper = mapper;
        }

        public async Task<Result<CatResponse>> Handle(GetCatByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                CatResponse res = this._mapper.Map<CatResponse>(await _catRepository.GetCatById(request.Id));

                return new Result<CatResponse>(res, new List<ValidationResult>());
            }
            catch (Exception ex)
            {
                return new Result<CatResponse>(new CatResponse(), new List<ValidationResult>());
            }
        }
    }
}
