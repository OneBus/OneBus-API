using OneBus.Application.DTOs.User;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.Application.Interfaces.Services
{
    public interface IUserService : 
        IBaseService<User, CreateUserDTO, ReadUserDTO, UpdateUserDTO, BaseFilter>
    {
    }
}
