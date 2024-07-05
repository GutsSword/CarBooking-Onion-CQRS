using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.AboutCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.AboutQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly CreateAboutCommandHandler createAboutCommandHandler;
        private readonly GetAboutByIdQueryHandler getAboutByIdQueryHandler;
        private readonly GetAboutQueryHandler getAboutQueryHandler;
        private readonly RemoveAboutCommandHandler removeAboutCommandHandler;
        private readonly UpdateAboutCommandHandler updateAboutCommandHandler;


        public AboutController(CreateAboutCommandHandler createAboutCommandHandler, GetAboutByIdQueryHandler getAboutByIdQueryHandler, GetAboutQueryHandler getAboutQueryHandler, RemoveAboutCommandHandler removeAboutCommandHandler, UpdateAboutCommandHandler updateAboutCommandHandler)
        {
            this.createAboutCommandHandler = createAboutCommandHandler;
            this.getAboutByIdQueryHandler = getAboutByIdQueryHandler;
            this.getAboutQueryHandler = getAboutQueryHandler;
            this.removeAboutCommandHandler = removeAboutCommandHandler;
            this.updateAboutCommandHandler = updateAboutCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var values = await getAboutQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAboutById(int id)
        {
            var values = await getAboutByIdQueryHandler.Handle(new GetAboutByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutCommand command)
        {
            await createAboutCommandHandler.Handle(command);
            return Ok("Hakkımda bilgisi eklendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            await removeAboutCommandHandler.Handle(new RemoveAboutCommand(id));
            return Ok("Hakkımda bilgisi silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommand command)
        {
            await updateAboutCommandHandler.Handle(command);
            return Ok("Hakkımda bilgisi güncellendi.");
        }
    }
}
