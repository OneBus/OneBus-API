using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using OneBus.Application.DTOs.Login;
using OneBus.Application.DTOs.User;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Commons;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using Swashbuckle.AspNetCore.Annotations;

namespace OneBus.API.Controllers
{
    [SwaggerTag("Controlador responsável por gerenciar Usuários")]
    public class UserController : BaseController<User, CreateUserDTO, ReadUserDTO, UpdateUserDTO, BaseFilter>
    {
        public UserController(
            IBaseService<User, CreateUserDTO, ReadUserDTO, UpdateUserDTO, BaseFilter> baseService) 
            : base(baseService)
        {
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
        [EnableRateLimiting("login")]
        [AllowAnonymous]
        [HttpPost("login")]
        public Task<IActionResult> LoginAsync([FromBody] LoginDTO login, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Cadastrar novo usuário 
        /// </summary>
        /// <remarks>
        /// POST de Usuário
        /// </remarks>
        /// <param name="createDTO">Campos para cadastrar usuário</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Usuário cadastrado</returns>
        /// <response code="200">Usuário cadastrado com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        [ProducesResponseType(typeof(SuccessResult<ReadUserDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadUserDTO>), StatusCodes.Status422UnprocessableEntity)]
        public override Task<IActionResult> CreateAsync([FromBody] CreateUserDTO createDTO, CancellationToken cancellationToken = default)
        {
            return base.CreateAsync(createDTO, cancellationToken);
        }

        /// <summary>
        /// Atualizar usuário 
        /// </summary>
        /// <remarks>
        /// PUT de Usuário
        /// </remarks>
        /// <param name="id">Id do usuário</param>
        /// <param name="updateDTO">Campos para atualizar usuário</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Usuário atualizado</returns>
        /// <response code="200">Usuário atualizado com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        /// <response code="404">Usuário não encontrado</response>
        /// <response code="409">Conflito entre ids</response>
        [ProducesResponseType(typeof(SuccessResult<ReadUserDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadUserDTO>), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(NotFoundResult<ReadUserDTO>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ConflictResult<ReadUserDTO>), StatusCodes.Status409Conflict)]
        public override Task<IActionResult> UpdateAsync([FromRoute] ulong id, [FromBody] UpdateUserDTO updateDTO, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(id, updateDTO, cancellationToken);
        }

        /// <summary>
        /// Habilitar usuário 
        /// </summary>
        /// <remarks>
        /// PUT para habilitar usuário 
        /// </remarks>
        /// <param name="id">Id do usuário</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Usuário habilitado</returns>
        /// <response code="200">Usuário habilitado com sucesso</response>
        /// <response code="404">Usuário não encontrado</response>
        [ProducesResponseType(typeof(SuccessResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<bool>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> EnableAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.EnableAsync(id, cancellationToken);
        }

        /// <summary>
        /// Desabilitar usuário 
        /// </summary>
        /// <remarks>
        /// DELETE de Usuário 
        /// </remarks>
        /// <param name="id">Id do usuário</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Usuário deletado</returns>
        /// <response code="200">Usuário deletado com sucesso</response>
        /// <response code="404">Usuário não encontrado</response>
        [ProducesResponseType(typeof(SuccessResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<bool>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> DisableAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.DisableAsync(id, cancellationToken);
        }

        /// <summary>
        /// Obter usuários paginados e filtrados
        /// </summary>
        /// <remarks>
        /// GET de Usuários
        /// </remarks>
        /// <param name="filter">Filtros para aplicar</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Usuários paginados e filtrados</returns>
        /// <response code="200">Usuários paginados e filtrados com sucesso</response>
        [ProducesResponseType(typeof(SuccessResult<Pagination<ReadUserDTO>>), StatusCodes.Status200OK)]
        public override Task<IActionResult> GetPaginedAsync([FromQuery] BaseFilter filter, CancellationToken cancellationToken = default)
        {
            return base.GetPaginedAsync(filter, cancellationToken);
        }

        /// <summary>
        /// Obter usuário por id
        /// </summary>
        /// <remarks>
        /// GET pelo id de usuário
        /// </remarks>
        /// <param name="id">Id do usuário</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Usuário encontrado</returns>
        /// <response code="200">Usuário encontrado com sucesso</response>
        /// <response code="404">Usuário não encontrado</response>
        [ProducesResponseType(typeof(SuccessResult<ReadUserDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<ReadUserDTO>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> GetByIdAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }
    }
}
