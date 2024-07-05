using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Results.ContactResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactQueryHandler
    {
        private readonly IRepository<Contact> repository;

        public GetContactQueryHandler(IRepository<Contact> repository)
        {
            this.repository = repository;
        }

        public async Task<List<GetContactQueryResult>> Handle()
        {
            var values = await repository.GetAllAsync();
            return values.Select(x => new GetContactQueryResult
            {
                ContactId = x.ContactId,
                Email = x.Email,
                Message = x.Message,
                SendDate = x.SendDate,
                Subject = x.Subject,
                Name = x.Name,

            }).ToList();
        }
    }
}
