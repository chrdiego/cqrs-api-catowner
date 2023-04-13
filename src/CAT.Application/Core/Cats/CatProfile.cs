using AutoMapper;
using CAT.Application.Contracts.Cats;
using CAT.Domain.Entities;

namespace CAT.Application.Core.Cats
{
    public class CatProfile : Profile
    {
        public CatProfile()
        {
            this.CreateMap<Cat, CatResponse>();
            this.CreateMap<CatResponse, Cat>();
        }
    }
}
