using Automarket.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Entities.Entities
{
    public class Car
    {
        public Guid CarId { get; set; }
        public string Name { get; set; }
        public DateTime Year { get; set; }
        public decimal Price { get; set; }
        public int Mileage { get; set; }
        public string Description { get; set; }

        public Brand Brand { get; set; }
        public CarType CarType { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
