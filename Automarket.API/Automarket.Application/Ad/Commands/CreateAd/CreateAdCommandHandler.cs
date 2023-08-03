using Automarket.Application.Common.Exceptions;
using Automarket.Domain.Entities;
using Automarket.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Application.Ad.Commands.CreateAd
{
    public class CreateAdCommandHandler : IRequestHandler<CreateAdCommand>
    {
        private readonly IAdRepository _repository;

        public CreateAdCommandHandler(IAdRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateAdCommand request, CancellationToken cancellationToken)
        {
            var (brand, model, carBody, year) = request;
            var entityId = Guid.NewGuid();

            var validator = new CreateAdCommandValidator();
            var validatonResult = validator.Validate(request);

            if (validatonResult.IsValid == false)
            {
                throw new ValidationException(validatonResult.Errors);
            }

            var adEntity = new Domain.Entities.Ad(entityId, brand, model, carBody, year);

            await _repository.AddAsync(adEntity, cancellationToken);

            return Unit.Value;
        }
    }
}
