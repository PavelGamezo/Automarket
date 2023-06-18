using Automarket.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Domain.ValueObjects
{
    public class CarBrand
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
    }
}
