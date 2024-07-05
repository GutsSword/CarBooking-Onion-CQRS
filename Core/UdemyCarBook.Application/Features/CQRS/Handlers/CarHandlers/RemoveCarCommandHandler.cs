
using UdemyCarBook.Application.Features.CQRS.Commands.CarCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class RemoveCarCommandHandler
    {
        private readonly IRepository<Car> repository;

        public RemoveCarCommandHandler(IRepository<Car> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(RemoveCarCommand command)
        {
            var values = await repository.GetByIdAsync(command.Id);
            await repository.RemoveAsync(values);
        }
    }
}
