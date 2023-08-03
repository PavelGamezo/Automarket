using Automarket.Application.Ad.Commands.CreateAd;
using Automarket.Application.Ad.Commands.DeleteAd;
using Automarket.Application.Ad.Queries.GetAdById;
using Automarket.Application.Ad.Queries.GetAds;
using Automarket.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Automarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AdDto>> Get(Guid id)
        {
            var ad = await _mediator.Send(new GetAdQuery(id));

            return Ok(ad);
        }

        [HttpGet]
        public async Task<ActionResult<AdDto>> GetAll()
        {
            var ads = await _mediator.Send(new GetAdsQuery());

            return Ok(ads);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAdCommand command)
        {
            await _mediator.Send(command);

            return Created(String.Empty, command);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteAdCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }
    }
}
