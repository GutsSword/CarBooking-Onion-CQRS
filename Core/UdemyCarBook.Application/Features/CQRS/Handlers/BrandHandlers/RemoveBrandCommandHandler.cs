using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.BrandCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class RemoveBrandCommandHandler
    {
        private readonly IRepository<Brand> repository;

        public RemoveBrandCommandHandler(IRepository<Brand> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(RemoveBrandCommand command)
        {
            var values = await repository.GetByIdAsync(command.Id);
            await repository.RemoveAsync(values);
        }
    }
}
