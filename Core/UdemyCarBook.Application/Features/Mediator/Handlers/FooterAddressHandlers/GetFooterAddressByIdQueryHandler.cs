﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.FooterAddressQueries;
using UdemyCarBook.Application.Features.Mediator.Results.FooterAddressResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressByIdQueryHandler : IRequestHandler<GetFooterAddressByIdQuery, GetFooterAddressByIdQueryResult>
    {
        private readonly IRepository<FooterAddress> repository;

        public GetFooterAddressByIdQueryHandler(IRepository<FooterAddress> repository)
        {
            this.repository = repository;
        }

        public async Task<GetFooterAddressByIdQueryResult> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await repository.GetByIdAsync(request.Id);
            return new GetFooterAddressByIdQueryResult
            {
                FooterAddressId = values.FooterAddressId,
                Address = values.Address,
                Description = values.Description,
                Email = values.Email,
                Phone = values.Phone,
            };
        }
    }
}
