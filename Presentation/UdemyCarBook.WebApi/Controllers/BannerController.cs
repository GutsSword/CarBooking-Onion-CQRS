using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.BannerCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.BannerQueries;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerController : ControllerBase
    {
        private readonly CreateBannerCommandHandler createBannerCommandHandler;
        private readonly GetBannerByIdQueryHandler getBannerByIdQueryHandler;
        private readonly GetBannerQueryHandler getBannerQueryHandler;
        private readonly RemoveBannerCommandHandler removeBannerCommandHandler;
        private readonly UpdateBannerCommandHandler updateBannerCommandHandler;

        public BannerController(CreateBannerCommandHandler createBannerCommandHandler, GetBannerByIdQueryHandler getBannerByIdQueryHandler, GetBannerQueryHandler getBannerQueryHandler, RemoveBannerCommandHandler removeBannerCommandHandler, UpdateBannerCommandHandler updateBannerCommandHandler)
        {
            this.createBannerCommandHandler = createBannerCommandHandler;
            this.getBannerByIdQueryHandler = getBannerByIdQueryHandler;
            this.getBannerQueryHandler = getBannerQueryHandler;
            this.removeBannerCommandHandler = removeBannerCommandHandler;
            this.updateBannerCommandHandler = updateBannerCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBanner()
        {
            var values = await getBannerQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBannerById(int id)
        {
            var values = await getBannerByIdQueryHandler.Handle(new GetBannerByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBanner (CreateBannerCommand banner)
        {
            await createBannerCommandHandler.Handle(banner);
            return Ok("Banner başarıyla eklendi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
        {
            await updateBannerCommandHandler.Handle(command);
            return Ok($"{command.BannerId} numaralı Banner başarıyla güncellendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBanner(int id)
        {
            await removeBannerCommandHandler.Handle(new RemoveBannerCommand(id));
            return Ok("Banner başarıyla silindi.");
        }
    }
}
