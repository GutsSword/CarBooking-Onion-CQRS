using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using UdemyCarBook.Application.Features.CQRS.Commands.BrandCommands;
using UdemyCarBook.Application.Features.CQRS.Commands.CarCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> repository;
        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateCarCommand command)
        {
            var value = await repository.GetByIdAsync(command.CarId);

            value.Fuel = command.Fuel;
            value.Transmission = command.Transmission;
            value.Seat = command.Seat;
            value.BigImageUrl = command.BigImageUrl;
            value.CarId = command.CarId;
            value.Km=command.Km;
            value.BrandId = command.BrandId;
            value.Model = command.Model;
            value.Luggage = command.Luggage;

            await repository.UpdateAsync(value);
        }
    }
}
