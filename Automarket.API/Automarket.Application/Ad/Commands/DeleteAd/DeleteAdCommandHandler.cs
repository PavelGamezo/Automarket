using Automarket.Application.Common.Commands;
using Automarket.Application.Common.Exceptions;
using Automarket.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Application.Ad.Commands.DeleteAd
{
    public class DeleteAdCommandHandler : ICommandHandler<DeleteAdCommand>
    {
        private readonly IAdRepository _repository;

        public DeleteAdCommandHandler(IAdRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteAdCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetAsync(request.Id, cancellationToken);

            if (entity is null)
            {
                throw new AdNotFoundException();
            }

            await _repository.DeleteAsync(entity, cancellationToken);

            return Unit.Value;
        }
    }
}
