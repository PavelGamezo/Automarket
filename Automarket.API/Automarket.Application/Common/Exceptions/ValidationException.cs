using FluentValidation.Results;

namespace Automarket.Application.Common.Exceptions
{
    public class ValidationException : Exception
    {

        public IDictionary<string, string[]> Errors { get; }

        public ValidationException() : base("One or more validation failures were occurred.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures)
        : this()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }
    }
}
