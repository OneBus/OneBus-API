using OneBus.Application.DTOs.UserType;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.Application.Interfaces.Services
{
    public interface IUserTypeService : IBaseService<UserType, CreateUserTypeDTO, ReadUserTypeDTO, UpdateUserTypeDTO, BaseFilter>
    {
    }
}
