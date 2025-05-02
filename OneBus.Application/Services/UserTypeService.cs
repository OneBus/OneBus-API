using FluentValidation;
using OneBus.Application.DTOs.UserType;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;

namespace OneBus.Application.Services
{
    public class UserTypeService : BaseService<UserType, CreateUserTypeDTO, ReadUserTypeDTO, UpdateUserTypeDTO, BaseFilter>,
        IUserTypeService
    {
        public UserTypeService(
            IBaseRepository<UserType, BaseFilter> baseRepository, 
            IValidator<CreateUserTypeDTO> createValidator, 
            IValidator<UpdateUserTypeDTO> updateValidator) 
            : base(baseRepository, createValidator, updateValidator)
        {
        }

        protected override void UpdateFields(UserType entity, UpdateUserTypeDTO updateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
