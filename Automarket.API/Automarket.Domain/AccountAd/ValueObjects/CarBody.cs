using Automarket.Domain.AccountAd.Exceptions;
using Automarket.Shared.Abstractions.Domain;

namespace Automarket.Domain.AccountAd.ValueObjects
{
    public class CarBody : ValueObject
    {
        public string Value { get; set; }

        public CarBody(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new EmptyCarBodyException();
            }
            Value = value;
        }

        public static implicit operator string(CarBody carBody) =>
            carBody.Value;

        public static implicit operator CarBody(string carBody) =>
            new(carBody);

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
