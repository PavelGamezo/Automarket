using Automarket.Application.Common.Commands;
using Automarket.Application.Common.Exceptions;
using Automarket.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Application.Ad.Commands.UpdateAd
{
    public class UpdateAdCommandHandler : ICommandHandler<UpdateAdCommand, Guid>
    {
        private readonly IAdRepository _repository;

        public UpdateAdCommandHandler(IAdRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(UpdateAdCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateAdCommandValidator();
            var validatonResult = validator.Validate(request);

            if (validatonResult.IsValid ==  false)
            {
                throw new ValidationException(validatonResult.Errors);
            }

            var entity = await _repository.GetAsync(request.Id, cancellationToken);

            if (entity is null)
            {
                throw new AdNotFoundException();
            }

            /*
            entity.Brand = request.Brand;
            entity.Model = request.Model;
            entity.CarBody = request.CarBody;
            entity.Year = request.Year;
            */

            await _repository.UpdateAsync(entity, cancellationToken);

            return entity.Id;
        }
    }
}
