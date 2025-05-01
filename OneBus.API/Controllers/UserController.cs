using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using OneBus.Application.DTOs.Login;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("login")]
        [AllowAnonymous]
        [EnableRateLimiting("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDTO login, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
