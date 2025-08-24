using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneBus.Application.DTOs.Login;
using OneBus.Application.Interfaces.Services;
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
        /// POST de Login
        /// </remarks>
        /// <param name="login"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Usuário autenticado</returns>
        [AllowAnonymous]
        [HttpPost("logins")]
        public Task<IActionResult> LoginAsync([FromBody] LoginDTO login, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
