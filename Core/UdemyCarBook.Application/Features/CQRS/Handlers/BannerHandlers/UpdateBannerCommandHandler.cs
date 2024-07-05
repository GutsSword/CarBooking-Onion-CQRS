using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.AboutCommands;
using UdemyCarBook.Application.Features.CQRS.Commands.BannerCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner> repository;
        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateBannerCommand command)
        {
            var value = await repository.GetByIdAsync(command.BannerId);

            value.Title = command.Title;
            value.Description = command.Description;
            value.VideoDescription = command.VideoDescription;
            value.VideoUrl = command.VideoUrl;

            await repository.UpdateAsync(value);

        }
    }
}
