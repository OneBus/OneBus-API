using OneBus.Application.DTOs.Feature;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;

namespace OneBus.Application.Services
{
    public class FeatureService : BaseReadOnlyService<Feature, ReadFeatureDTO, BaseFilter>, IFeatureService
    {
        public FeatureService(IBaseReadOnlyRepository<Feature, BaseFilter> baseReadOnlyRepository) : base(baseReadOnlyRepository)
        {
        }
    }
}
