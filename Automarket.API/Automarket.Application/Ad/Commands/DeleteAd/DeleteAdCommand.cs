using Automarket.Application.Common.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Application.Ad.Commands.DeleteAd
{
    public record class DeleteAdCommand(Guid Id) : ICommand;
}
