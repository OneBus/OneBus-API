﻿using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.Domain.Interfaces.Repositories
{
    public interface IFeatureRepository : IBaseReadOnlyRepository<Feature, BaseFilter>
    {
    }
}
