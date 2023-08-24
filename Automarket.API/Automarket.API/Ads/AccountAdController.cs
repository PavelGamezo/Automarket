using Automarket.API.AccountAds;
using Automarket.Application.Ad.Commands.CreateAd;
using Automarket.Application.Ad.Commands.DeleteAd;
using Automarket.Application.Ad.Commands.UpdateAd;
using Automarket.Application.Ad.Queries.GetAds;
using Automarket.Application.DTOs;
using Automarket.Shared.Abstractions.ResultObjects;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Automarket.API.Ads
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountAdController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountAdController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get account ads
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        [Route("{accountId}/ads")]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAccountAds(Guid accountId)
        {
            Result<List<AdDto>> adsResult = await _mediator.Send(new GetAdDetailsQuery(accountId));

            if (adsResult.IsFailure)
            {
                return BadRequest(adsResult);
            }

            return Ok(adsResult.Value);
        }

        /// <summary>
        /// Get account ad details
        /// </summary>
        /// <param name="adId"></param>
        /// <returns></returns>
        [Route("{accountId}/ads/{adId}")]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAdDetail(
            [FromRoute] Guid adId)
        {
            Result<List<AdDto>> result = await _mediator.Send(new GetAdDetailsQuery(adId));

            return result.IsSuccess ? Ok(result.Value) : BadRequest(result);
        }

        /// <summary>
        /// Add account ad
        /// </summary>
        /// <param name="command"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        [Route("{accountId}/orders")]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddAccountAd(
            [FromBody] AccountAdRequest request,
            [FromRoute] Guid accountId)
        {
            var result = await _mediator.Send(new PlaceAccountAdCommand(
                accountId,
                request.Brand,
                request.Model,
                request.CarBody,
                request.Year));

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Created(string.Empty, null);
        }

        /// <summary>
        /// Remove account ad
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="adId"></param>
        /// <returns></returns>
        [Route("{accountId}/ads/{adId}")]
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> RemoveAccountAd(
            [FromRoute]Guid accountId,
            [FromRoute]Guid adId)
        {
            var result = await _mediator.Send(new RemoveAccountAdCommand(accountId, adId));
            
            return result.IsSuccess ? Ok() : NotFound(result.Error);
        }

        public async Task<IActionResult> UpdateAccountAd(
            [FromRoute] Guid accountId,
            [FromRoute] Guid adId,
            [FromBody] AccountAdRequest request)
        {
            var result = await _mediator.Send(new UpdateAccountAdCommand(accountId, 
                adId, 
                request.Brand, 
                request.Model, 
                request.CarBody, 
                request.Year));

            return result.IsSuccess? Ok(result.Value) : NotFound(result.Error);
        }
    }
}
