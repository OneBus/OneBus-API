using OneBus.Application.DTOs.Login;
using OneBus.Application.DTOs.User;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Models;

namespace OneBus.Application.Interfaces.Services
{
    public interface IUserService : 
        IBaseService<User, CreateUserDTO, ReadUserDTO, UpdateUserDTO, BaseFilter>
    {
        public Task<Result<TokenModel>> LoginAsync(
            LoginDTO loginDTO,
            CancellationToken cancellationToken = default);
    }
}
