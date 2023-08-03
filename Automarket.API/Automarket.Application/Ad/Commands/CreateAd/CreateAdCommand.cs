using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Application.Ad.Commands.CreateAd
{
    public record class CreateAdCommand(string Brand, string Model, string CarBody, int Year) : IRequest;
}
