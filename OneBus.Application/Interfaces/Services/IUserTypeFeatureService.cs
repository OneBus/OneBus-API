using OneBus.Application.DTOs.UserTypeFeature;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.Application.Interfaces.Services
{
    public interface IUserTypeFeatureService : IBaseService<UserTypeFeature, CreateUserTypeFeatureDTO, ReadUserTypeFeatureDTO, UpdateUserTypeFeatureDTO, BaseFilter>
    {
        Task<bool> HasPermissionAsync(ulong userId, byte featureCode, CancellationToken cancellationToken = default);
    }
}
