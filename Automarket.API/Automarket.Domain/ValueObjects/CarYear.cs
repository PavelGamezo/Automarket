using Automarket.Domain.Exceptions;
using Automarket.Shared.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Domain.ValueObjects
{
    public class CarYear : ValueObject
    {
        public int Value { get; set; }

        public CarYear(int value)
        {
            if (value == 0)
            {
                throw new EmptyCarYearException();
            }
            Value = value;
        }

        public static implicit operator int(CarYear carYear) =>
            carYear.Value;

        public static implicit operator CarYear(int carYear) =>
            new CarYear(carYear);

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
