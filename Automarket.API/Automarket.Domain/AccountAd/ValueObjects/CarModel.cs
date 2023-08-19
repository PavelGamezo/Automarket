using Automarket.Domain.AccountAd.Exceptions;
using Automarket.Shared.Abstractions.Domain;

namespace Automarket.Domain.AccountAd.ValueObjects
{
    public class CarModel : ValueObject
    {
        public string Value { get; set; }

        public CarModel(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new EmptyCarModelException();
            }
            Value = value;
        }

        public static implicit operator string(CarModel carModel) =>
            carModel.Value;

        public static implicit operator CarModel(string carModel) =>
            new(carModel);

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
