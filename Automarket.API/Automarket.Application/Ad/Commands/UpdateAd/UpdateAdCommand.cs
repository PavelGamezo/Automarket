using Automarket.Application.Common.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Application.Ad.Commands.UpdateAd
{
    public record class UpdateAdCommand(Guid Id, string Brand, string Model, string CarBody, int Year) : ICommand<Guid>;
}
