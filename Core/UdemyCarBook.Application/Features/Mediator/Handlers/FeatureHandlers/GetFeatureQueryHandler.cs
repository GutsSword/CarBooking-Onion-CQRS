﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.FeaturesQueries;
using UdemyCarBook.Application.Features.Mediator.Results.FeatureResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>>
    {
        private readonly IRepository<Feature> repository;

        public GetFeatureQueryHandler(IRepository<Feature> repository)
        {
            this.repository = repository;
        }

        public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
        {
            var values = await repository.GetAllAsync();
            return values.Select(x => new GetFeatureQueryResult
            {
                FeatureId = x.FeatureId,
                Name = x.Name,
            }).ToList();
        }
    }
}
