using Automarket.Domain.Events;
using Automarket.Domain.ValueObjects;
using Automarket.Shared.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Domain.Entities
{
    public sealed class Ad : Entity
    {
        private bool _done;

        public CarBrand Brand { get; set; }
        public CarModel Model { get; set; }
        public CarBody CarBody { get; set; }
        public CarYear Year { get; set; }
        public bool Done
        {
            get => _done;
            set
            {
                if(value && !_done)
                {
                    AddDomainEvent(new AdCompletedEvent(this));
                }
            }
        }

        public Ad(Guid id, CarBrand brand, CarModel model, CarBody carBody, CarYear year) : base(id)
        {
            Brand = brand;
            Model = model;
            CarBody = carBody;
            Year = year;
        }


    }
}
