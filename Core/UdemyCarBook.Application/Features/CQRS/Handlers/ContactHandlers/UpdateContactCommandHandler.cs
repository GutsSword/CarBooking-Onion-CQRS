using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.AboutCommands;
using UdemyCarBook.Application.Features.CQRS.Commands.ContactCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class UpdateContactCommandHandler
    {
        private readonly IRepository<Contact> repository;

        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateContactCommand command)
        {
            var value = await repository.GetByIdAsync(command.ContactId);

            value.ContactId = command.ContactId;
            value.Name = command.Name;
            value.Email = command.Email;
            value.SendDate = command.SendDate;
            value.Subject = command.Subject;
            value.Message = command.Message;
            value.Subject = command.Subject;

            await repository.UpdateAsync(value);
        }
    }
}
