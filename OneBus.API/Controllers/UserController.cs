using OneBus.Application.DTOs.User;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.API.Controllers
{
    public class UserController : BaseController<User, CreateUserDTO, ReadUserDTO, UpdateUserDTO, BaseFilter>
    {
        public UserController(
            IBaseService<User, CreateUserDTO, ReadUserDTO, UpdateUserDTO, BaseFilter> baseService) 
            : base(baseService)
        {
        }
    }
}
