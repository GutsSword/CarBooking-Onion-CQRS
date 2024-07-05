using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.ContactCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class RemoveContactCommandHandler
    {
        private readonly IRepository<Contact> repository;
        public RemoveContactCommandHandler(IRepository<Contact> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(RemoveContactCommand command)
        {
            var values = await repository.GetByIdAsync(command.Id);
            await repository.RemoveAsync(values);
        }
    }
}
