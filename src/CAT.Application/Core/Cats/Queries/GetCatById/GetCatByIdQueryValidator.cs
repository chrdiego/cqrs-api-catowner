using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace CAT.Application.Core.Cats.Queries.GetCatById
{
    public sealed class GetCatByIdQueryValidator : AbstractValidator<GetCatByIdQuery>
    {
        public GetCatByIdQueryValidator() 
        { 
            this.RuleFor(x => x.Id).GreaterThan(5).WithMessage("more than 5");
        }
    }
}
