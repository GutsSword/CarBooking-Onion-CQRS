using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Queries.BrandQueries;
using UdemyCarBook.Application.Features.CQRS.Queries.CarQueries;
using UdemyCarBook.Application.Features.CQRS.Results.BrandResults;
using UdemyCarBook.Application.Features.CQRS.Results.CarResult;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> repository;
        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            this.repository = repository;
        }

        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
        {
            var values = await repository.GetByIdAsync(query.Id);
            return new GetCarByIdQueryResult
            {
               BigImageUrl = values.BigImageUrl,
               CarId = values.CarId,
               CoverImageUrl = values.CoverImageUrl,
               Fuel = values.Fuel,
               BrandId = values.BrandId,
               Transmission = values.Transmission,
               Seat = values.Seat,
               Model = values.Model,
               Luggage = values.Luggage,
               Km = values.Km
            };

        }
    }
}
