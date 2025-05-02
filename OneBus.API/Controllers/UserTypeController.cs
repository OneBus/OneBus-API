using Microsoft.AspNetCore.Mvc;
using OneBus.Application.DTOs.UserType;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Commons;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using Swashbuckle.AspNetCore.Annotations;

namespace OneBus.API.Controllers
{
    [SwaggerTag("Controlador responsável por gerenciar Tipos de Usuários")]
    public class UserTypeController : BaseController<UserType, CreateUserTypeDTO, ReadUserTypeDTO, UpdateUserTypeDTO, BaseFilter>
    {
        public UserTypeController(IBaseService<UserType, CreateUserTypeDTO, ReadUserTypeDTO, UpdateUserTypeDTO, BaseFilter> baseService) 
            : base(baseService)
        {
        }

        /// <summary>
        /// Cadastrar novo tipo de usuário 
        /// </summary>
        /// <remarks>
        /// POST de Tipo de Usuário
        /// </remarks>
        /// <param name="createDTO">Campos para cadastrar tipo de usuário</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Tipo de Usuário cadastrado</returns>
        /// <response code="200">Tipo de Usuário cadastrado com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        [ProducesResponseType(typeof(SuccessResult<ReadUserTypeDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadUserTypeDTO>), StatusCodes.Status422UnprocessableEntity)]
        public override Task<IActionResult> CreateAsync([FromBody] CreateUserTypeDTO createDTO, CancellationToken cancellationToken = default)
        {
            return base.CreateAsync(createDTO, cancellationToken);
        }

        /// <summary>
        /// Atualizar tipo de usuário 
        /// </summary>
        /// <remarks>
        /// PUT de Tipo de Usuário
        /// </remarks>
        /// <param name="id">Id do tipo de usuário</param>
        /// <param name="updateDTO">Campos para atualizar tipo de usuário</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Tipo de Usuário atualizado</returns>
        /// <response code="200">Tipo de Usuário atualizado com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        /// <response code="404">Tipo de Usuário não encontrado</response>
        /// <response code="409">Conflito entre ids</response>
        [ProducesResponseType(typeof(SuccessResult<ReadUserTypeDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadUserTypeDTO>), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(NotFoundResult<ReadUserTypeDTO>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ConflictResult<ReadUserTypeDTO>), StatusCodes.Status409Conflict)]
        public override Task<IActionResult> UpdateAsync([FromRoute] ulong id, [FromBody] UpdateUserTypeDTO updateDTO, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(id, updateDTO, cancellationToken);
        }

        /// <summary>
        /// Habilitar tipo de usuário 
        /// </summary>
        /// <remarks>
        /// PUT para habilitar tipo de usuário 
        /// </remarks>
        /// <param name="id">Id do tipo de usuário</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Tipo de Usuário habilitado</returns>
        /// <response code="200">Tipo de Usuário habilitado com sucesso</response>
        /// <response code="404">Tipo de Usuário não encontrado</response>
        [ProducesResponseType(typeof(SuccessResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<bool>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> EnableAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.EnableAsync(id, cancellationToken);
        }

        /// <summary>
        /// Desabilitar tipo de usuário 
        /// </summary>
        /// <remarks>
        /// DELETE de Tipo de Usuário 
        /// </remarks>
        /// <param name="id">Id do tipo de usuário</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Tipo de Usuário deletado</returns>
        /// <response code="200">Tipo de Usuário deletado com sucesso</response>
        /// <response code="404">Tipo de Usuário não encontrado</response>
        [ProducesResponseType(typeof(SuccessResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<bool>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> DisableAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.DisableAsync(id, cancellationToken);
        }

        /// <summary>
        /// Obter tipos de usuários paginados e filtrados
        /// </summary>
        /// <remarks>
        /// GET de Tipos de Usuários
        /// </remarks>
        /// <param name="filter">Filtros para aplicar</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Tipos de Usuários paginados e filtrados</returns>
        /// <response code="200">Tipos de Usuários paginados e filtrados com sucesso</response>
        [ProducesResponseType(typeof(SuccessResult<Pagination<ReadUserTypeDTO>>), StatusCodes.Status200OK)]
        public override Task<IActionResult> GetPaginedAsync([FromQuery] BaseFilter filter, CancellationToken cancellationToken = default)
        {
            return base.GetPaginedAsync(filter, cancellationToken);
        }

        /// <summary>
        /// Obter tipo de usuário por id
        /// </summary>
        /// <remarks>
        /// GET pelo id de tipo de usuário
        /// </remarks>
        /// <param name="id">Id do tipo de usuário</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Tipo de Usuário encontrado</returns>
        /// <response code="200">Tipo de Usuário encontrado com sucesso</response>
        /// <response code="404">Tipo de Usuário não encontrado</response>
        [ProducesResponseType(typeof(SuccessResult<ReadUserTypeDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<ReadUserTypeDTO>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> GetByIdAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }
    }
}
