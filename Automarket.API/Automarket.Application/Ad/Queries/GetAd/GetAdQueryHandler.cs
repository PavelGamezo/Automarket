using Automarket.Application.Ad.Queries.GetAdById;
using Automarket.Application.Common.Exceptions;
using Automarket.Application.DTOs;
using Automarket.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Application.Ad.Queries.GetAd
{
    public class GetAdQueryHandler : IRequestHandler<GetAdQuery, AdDto>
    {
        private readonly IAdRepository _repository;

        public GetAdQueryHandler(IAdRepository repository)
        {
            _repository = repository;
        }

        public async Task<AdDto> Handle(GetAdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetAsync(request.Id, cancellationToken);

            if (entity is null)
            {
                throw new AdNotFoundException();
            }

            return new AdDto(entity.Id, entity.CarBody, entity.Brand, entity.Model, entity.Year);
        }
    }
}
