using FluentValidation;
using OneBus.Application.DTOs.User;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;

namespace OneBus.Application.Services
{
    public class UserService : BaseService<User, CreateUserDTO, ReadUserDTO, UpdateUserDTO, BaseFilter>,
        IUserService
    {
        public UserService(
            IBaseRepository<User, BaseFilter> baseRepository, 
            IValidator<CreateUserDTO> createValidator, 
            IValidator<UpdateUserDTO> updateValidator) 
            : base(baseRepository, createValidator, updateValidator)
        {
        }

        protected override void UpdateFields(User entity, UpdateUserDTO updateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
