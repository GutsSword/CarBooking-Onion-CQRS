
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.BrandCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.BrandQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly CreateBrandCommandHandler createBrandCommandHandler;
        private readonly GetBrandByIdQueryHandler getBrandByIdQueryHandler;
        private readonly GetBrandQueryHandler getBrandQueryHandler;
        private readonly RemoveBrandCommandHandler removeBrandCommandHandler;
        private readonly UpdateBrandCommandHandler updateBrandCommandHandler;

        public BrandController(CreateBrandCommandHandler createBrandCommandHandler, GetBrandByIdQueryHandler getBrandByIdQueryHandler, GetBrandQueryHandler getBrandQueryHandler, RemoveBrandCommandHandler removeBrandCommandHandler, UpdateBrandCommandHandler updateBrandCommandHandler)
        {
            this.createBrandCommandHandler = createBrandCommandHandler;
            this.getBrandByIdQueryHandler = getBrandByIdQueryHandler;
            this.getBrandQueryHandler = getBrandQueryHandler;
            this.removeBrandCommandHandler = removeBrandCommandHandler;
            this.updateBrandCommandHandler = updateBrandCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBrand()
        {
            var values = await getBrandQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandById(int id)
        {
            var values = await getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommand Brand)
        {
            await createBrandCommandHandler.Handle(Brand);
            return Ok("Brand başarıyla eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBrand(UpdateBrandCommand command)
        {
            await updateBrandCommandHandler.Handle(command);
            return Ok($"{command.BrandId} numaralı Brand başarıyla güncellendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            await removeBrandCommandHandler.Handle(new RemoveBrandCommand(id));
            return Ok("Brand başarıyla silindi.");
        }
    }
}
