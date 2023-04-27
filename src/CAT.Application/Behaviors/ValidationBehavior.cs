using FluentValidation;
using MediatR;
using ValidationException = CAT.Application.Exceptions.ValidationException;

namespace CAT.Application.Behaviors
{
    internal sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : class, IRequest<TResponse>
        where TResponse : class
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            this._validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellation)
        {
            if (!_validators.Any())
            {
                return await next();
            }

            //var context = new ValidationContext<TRequest>(request);

            //var failures = _validators
            //    .Select(v => v.Validate(context))
            //    .SelectMany(result => result.Errors)
            //    .Where(f => f != null)
            //    .ToList();

            //if (failures.Count != 0)
            //{
            //    throw new ValidationException(failures);
            //}

            return await next();
        }
    }
}
