using Automarket.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Domain.Entities
{
    public class Car
    {
        public CarId Id { get; private set; }
        public CarBrand Brand { get; private set; }
        public string Model { get; private set; }
        public string Specification { get; private set; }
        public string CarBody { get; private set; }
        public DateTime Year { get; private set; }

        public Car(CarId id, CarBrand brand, string model, string specification, string carBody, DateTime year)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Specification = specification;
            CarBody = carBody;
            Year = year;
        }


    }
}
