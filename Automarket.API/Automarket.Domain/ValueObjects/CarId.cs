using Automarket.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Domain.ValueObjects
{
    public class CarId
    {
        public Guid Value { get; private set; }

        public CarId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new EmptyCarIdException();
            }

            Value = value;
        }

        public static implicit operator Guid(CarId id) =>
            id.Value;

        public static implicit operator CarId(Guid id) =>
            new(id);
    }
}
