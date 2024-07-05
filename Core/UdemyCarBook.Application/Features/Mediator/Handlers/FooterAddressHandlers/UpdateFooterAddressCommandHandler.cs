using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.FeatureCommands;
using UdemyCarBook.Application.Features.Mediator.Commands.FooterAddressCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class UpdateFooterAddressCommandHandler : IRequestHandler<UpdateFooterAddressCommand>
    {
        private readonly IRepository<FooterAddress> repository;

        public UpdateFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var values = await repository.GetByIdAsync(request.FooterAddressId);

            values.Phone = request.Phone;
            values.Address = request.Address;
            values.FooterAddressId = request.FooterAddressId;
            values.Description = request.Description;
            values.Email = request.Email;

            await repository.UpdateAsync(values);
        }
    }
}
