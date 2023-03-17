using AutoMapper;
using Automarket.BusinessLayer.Dtos;
using Automarket.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.BusinessLayer.Services.Cars
{
    public class CarMapProfile : Profile
    {
        public CarMapProfile()
        {
            CreateMap<Car, CarDto>().ReverseMap();
        }
    }
}
