using System.Net;
using CAT.Domain.Primitives;
using FluentValidation.Results;

namespace CAT.Application.Exceptions
{
    public class ValidationException : BaseException
    {
        public IDictionary<string, string[]> Failures { get; }

        public ValidationException()
            : base(
                "One or more validation failures have courred.",
                (int)HttpStatusCode.UnprocessableEntity)
        {
            this.Failures = new Dictionary<string, string[]>();
        }

        public ValidationException(List<ValidationFailure> failures)
            : this()
        {
            IEnumerable<string> propertyNames = failures
                                         .Select(e => e.PropertyName)
                                            .Distinct();
            foreach (string propertyName in propertyNames)
            {
                var propertyValue = failures.
                    Where(e => e.PropertyName == propertyName)
                    .Select(e => e.ErrorMessage)
                    .ToArray();
                this.Failures.Add(propertyName, propertyValue);
            }
        }
    }
}
