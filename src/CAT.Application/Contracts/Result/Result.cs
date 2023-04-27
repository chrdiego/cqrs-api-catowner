using CAT.Domain.Primitives;
using FluentValidation.Results;

namespace CAT.Application.Contracts.Result
{
    public class Result<T> where T : IResult
    {
        public readonly IReadOnlyCollection<ValidationResult> Notifications;

        public Result(T result, IReadOnlyCollection<ValidationResult> notifications, string statusCode = "OK", Error error = null)
        {
            this.result = result;
            this.Notifications = notifications;
            this.StatusCode = statusCode;
            this.Error = error;
        }

        public Error Error { get; set; }

        public string StatusCode { get; set; }

        public T result { get; set; }

        public bool IsValid => this.Notifications.Count == 0
                            || this.Notifications.All(x => x.IsValid);
    }
}
