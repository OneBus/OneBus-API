using OneBus.Application.DTOs.Feature;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.Application.Interfaces.Services
{
    public interface IFeatureService : IBaseReadOnlyService<Feature, ReadFeatureDTO, BaseFilter>
    {
    }
}
