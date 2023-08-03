using Automarket.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Application.Ad.Queries.GetAdById
{
    public record class GetAdQuery(Guid Id) : IRequest<AdDto>;
}
