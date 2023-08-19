using Automarket.Application.Account.Commands.DeleteAccount;
using Automarket.Application.Authentication.Commands.Register;
using Automarket.Application.Authentication.Queries.Login;
using Automarket.Shared.Abstractions.ResultObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Automarket.API.Accounts
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginAccount(
            [FromBody] LoginQuery request,
            CancellationToken cancellationToken)
        {
            Result<string> tokenResult = await _mediator.Send(request, cancellationToken);

            if (tokenResult.IsFailure)
            {
                return BadRequest(tokenResult);
            }

            return Ok(tokenResult.Value);
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterAccount(
            RegisterCommand request,
            CancellationToken cancellationToken)
        {
            Result registrationResult = await _mediator.Send(request, cancellationToken);

            if (registrationResult.IsFailure)
            {
                return BadRequest(registrationResult);
            }

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAccount(
            DeleteAccountCommand request,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok();
        }
    }
}
