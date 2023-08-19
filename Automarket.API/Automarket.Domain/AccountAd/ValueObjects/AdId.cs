using Automarket.Domain.AccountAd.Exceptions;
using Automarket.Shared.Abstractions.Domain;

namespace Automarket.Domain.AccountAd.ValueObjects
{
    public class AdId : ValueObject
    {
        public Guid Value { get; set; }

        public AdId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new EmptyCarIdException();
            }
            Value = value;
        }

        public static implicit operator Guid(AdId carBody) =>
            carBody.Value;

        public static implicit operator AdId(Guid carBody) =>
            new(carBody);

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
