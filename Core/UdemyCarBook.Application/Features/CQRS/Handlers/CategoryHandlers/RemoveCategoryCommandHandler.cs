using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.CategoryCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler
    {
        private readonly IRepository<Category> repository;
        public RemoveCategoryCommandHandler(IRepository<Category> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(RemoveCategoryCommand command)
        {
            var values = await repository.GetByIdAsync(command.Id);
            await repository.RemoveAsync(values);
        }
    }
}
