using Automarket.Domain.Exceptions;
using Automarket.Shared.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Domain.ValueObjects
{
    public class CarModel : ValueObject
    {
        public string Value { get; set; }

        public CarModel(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new EmptyCarBrandException();
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
