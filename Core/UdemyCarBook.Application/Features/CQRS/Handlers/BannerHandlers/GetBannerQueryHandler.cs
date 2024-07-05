using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Results.BannerResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerQueryHandler
    {
        private readonly IRepository<Banner> repository;
        public GetBannerQueryHandler(IRepository<Banner> repository)
        {
            this.repository = repository;
        }

        public async Task<List<GetBannerQueryResult>> Handle()
        {
            var values = await repository.GetAllAsync();
            return values.Select(x => new GetBannerQueryResult
            {
                BannerId = x.BannerId,
                Title = x.Title,
                VideoDescription = x.VideoDescription,
                VideoUrl = x.VideoUrl,
                Description = x.Description
            }).ToList();
        }
    }
}
