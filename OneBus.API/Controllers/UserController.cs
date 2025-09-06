using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneBus.API.Extensions;
using OneBus.Application.DTOs.Login;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace OneBus.API.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    [SwaggerTag("Controlador responsável por gerenciar Usuários")]
    public class UserController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Efetuar login
        /// </summary>
        /// <remarks>
        /// Exemplo:
        /// 
        ///     POST /logins
        ///     {
        ///         "email": "helloworld@gmail.com",
        ///         "password": "dasdfsf35346353tsd"
        ///     }
        /// </remarks>
        /// <param name="login"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Usuário autenticado</returns>
        [AllowAnonymous]
        [HttpPost("logins")]
        [ProducesResponseType(typeof(SuccessResult<TokenModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<TokenModel>), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(NotFoundResult<TokenModel>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDTO login, CancellationToken cancellationToken = default)
        {
            return (await _userService.LoginAsync(login, cancellationToken)).ToActionResult();
        }
    }
}
