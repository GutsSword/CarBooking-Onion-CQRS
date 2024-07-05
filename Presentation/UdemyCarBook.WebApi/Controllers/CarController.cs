
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.CarCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.CarQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CreateCarCommandHandler createCarCommandHandler;
        private readonly GetCarByIdQueryHandler getCarByIdQueryHandler;
        private readonly GetCarQueryHandler getCarQueryHandler;
        private readonly RemoveCarCommandHandler removeCarCommandHandler;
        private readonly UpdateCarCommandHandler updateCarCommandHandler;
        private readonly GetCarWithBrandQueryHandler getCarWithBrandQueryHandler;

        public CarController(CreateCarCommandHandler createCarCommandHandler, GetCarByIdQueryHandler getCarByIdQueryHandler, GetCarQueryHandler getCarQueryHandler, RemoveCarCommandHandler removeCarCommandHandler, UpdateCarCommandHandler updateCarCommandHandler, GetCarWithBrandQueryHandler getCarWithBrandQueryHandler)
        {
            this.createCarCommandHandler = createCarCommandHandler;
            this.getCarByIdQueryHandler = getCarByIdQueryHandler;
            this.getCarQueryHandler = getCarQueryHandler;
            this.removeCarCommandHandler = removeCarCommandHandler;
            this.updateCarCommandHandler = updateCarCommandHandler;
            this.getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCar()
        {
            var values = await getCarQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("GetCarWithBrand")]
        public async Task<IActionResult> GetCarWithBrand()
        {
            var values = await getCarWithBrandQueryHandler.Handle();
            return Ok(values);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarById(int id)
        {
            var values = await getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommand Car)
        {
            await createCarCommandHandler.Handle(Car);
            return Ok("Car başarıyla eklendi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
        {
            await updateCarCommandHandler.Handle(command);
            return Ok($"{command.CarId} numaralı Car başarıyla güncellendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCar(int id)
        {
            await removeCarCommandHandler.Handle(new RemoveCarCommand(id));
            return Ok("Car başarıyla silindi.");
        }
    }
}
