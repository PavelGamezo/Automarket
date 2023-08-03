using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Application.DTOs
{
    public record class AdDto(Guid AdId, string CarBody, string CarBrand, string CarModel, int CarYear);
}
