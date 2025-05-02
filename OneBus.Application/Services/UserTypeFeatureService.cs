using FluentValidation;
using OneBus.Application.DTOs.UserTypeFeature;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;

namespace OneBus.Application.Services
{
    public class UserTypeFeatureService : BaseService<UserTypeFeature, CreateUserTypeFeatureDTO, ReadUserTypeFeatureDTO, UpdateUserTypeFeatureDTO, BaseFilter>,
        IUserTypeFeatureService
    {
        public UserTypeFeatureService(
            IBaseRepository<UserTypeFeature, BaseFilter> baseRepository, 
            IValidator<CreateUserTypeFeatureDTO> createValidator, 
            IValidator<UpdateUserTypeFeatureDTO> updateValidator) 
            : base(baseRepository, createValidator, updateValidator)
        {
        }

        public Task<bool> HasPermissionAsync(ulong userId, byte featureCode, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        protected override void UpdateFields(UserTypeFeature entity, UpdateUserTypeFeatureDTO updateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
