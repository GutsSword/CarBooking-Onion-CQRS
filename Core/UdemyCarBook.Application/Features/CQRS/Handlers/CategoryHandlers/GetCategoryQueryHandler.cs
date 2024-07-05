using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Results.CarResult;
using UdemyCarBook.Application.Features.CQRS.Results.CategoryResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler
    {
        private readonly IRepository<Category> repository;

        public GetCategoryQueryHandler(IRepository<Category> repository)
        {
            this.repository = repository;
        }

        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            var values = await repository.GetAllAsync();
            return values.Select(x => new GetCategoryQueryResult
            {
               CategoryId  = x.CategoryId,
               Name = x.Name,

            }).ToList();
        }
    }
}
