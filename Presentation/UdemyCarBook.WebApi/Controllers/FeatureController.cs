using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.FeatureCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.FeaturesQueries;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Repositories;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IMediator mediator;

        public FeatureController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetFeatures()
        {
            var values = await mediator.Send(new GetFeatureQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdFeature(int id)
        {
            var values = await mediator.Send(new GetFeatureByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureCommand command)
        {
            await mediator.Send(command);
            return Ok("Feature başarıyla eklendi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureCommand command)
        {
            await mediator.Send(command);
            return Ok("Feature başarıyla güncellendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveFeature(int id)
        {
            await mediator.Send(new RemoveFeatureCommand(id));
            return Ok("Feature başarıyla silindi.");
        }
    }
}
