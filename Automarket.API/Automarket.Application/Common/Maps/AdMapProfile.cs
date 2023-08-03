using AutoMapper;
using Automarket.Application.DTOs;
using Automarket.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Application.Common.Maps
{
    /*
    public class AdMapProfile : Profile
    {
        public AdMapProfile()
        {
            CreateMap<Domain.Entities.Ad, AdDto>()
                .ReverseMap()
                .ForMember(q => q.CarBody, w=>w.ConvertUsing<CarBodyConverter, CarBody>(q=>q.));
        }
    }

    public class CarBodyConverter : IValueConverter<CarBody, string>
    {
        public string Convert(CarBody sourceMember, ResolutionContext context)
        {
            return sourceMember.Value;
        }
    }
    */
}
