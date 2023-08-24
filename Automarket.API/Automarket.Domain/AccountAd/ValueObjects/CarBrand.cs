using Automarket.Domain.AccountAd.Exceptions;

namespace Automarket.Domain.AccountAd.ValueObjects
{
    public class CarBrand : ValueObject
    {
        public string Value { get; set; }

        public CarBrand(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new EmptyCarBrandException();
            }
            Value = value;
        }

        public static implicit operator string(CarBrand carBrand) =>
            carBrand.Value;

        public static implicit operator CarBrand(string carBrand) =>
            new(carBrand);

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
