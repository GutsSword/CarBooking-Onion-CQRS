﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.BrandCommands;
using UdemyCarBook.Application.Features.CQRS.Commands.CarCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class CreateCarCommandHandler
    {
        private readonly IRepository<Car> repository;
        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(CreateCarCommand command)
        {
            await repository.CreateAsync(new Car
            {
                BigImageUrl = command.BigImageUrl,
                Luggage = command.Luggage,
                Fuel = command.Fuel,
                Km = command.Km,
                Seat = command.Seat,
                Transmission = command.Transmission,
                Model = command.Model,
                CoverImageUrl = command.CoverImageUrl,
                BrandId = command.BrandId,            
                
            });

        }
    }
}
