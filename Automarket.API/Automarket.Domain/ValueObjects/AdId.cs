using Automarket.Domain.Exceptions;
using Automarket.Shared.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Domain.ValueObjects
{
    public class AdId : ValueObject
    {
        public Guid Value { get; set; }

        public AdId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new EmptyCarBodyException();
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
