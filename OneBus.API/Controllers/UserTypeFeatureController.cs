using Microsoft.AspNetCore.Mvc;
using OneBus.Application.DTOs.UserTypeFeature;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Commons;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using Swashbuckle.AspNetCore.Annotations;

namespace OneBus.API.Controllers
{
    [SwaggerTag("Controlador responsável por gerenciar Funcionalidades de Tipos de Usuários")]
    public class UserTypeFeatureController : BaseController<UserTypeFeature, CreateUserTypeFeatureDTO, ReadUserTypeFeatureDTO, UpdateUserTypeFeatureDTO, BaseFilter>
    {
        public UserTypeFeatureController(IBaseService<UserTypeFeature, CreateUserTypeFeatureDTO, ReadUserTypeFeatureDTO, UpdateUserTypeFeatureDTO, BaseFilter> baseService) 
            : base(baseService)
        {
        }

        /// <summary>
        /// Cadastrar nova funcionalidade de tipo de usuário 
        /// </summary>
        /// <remarks>
        /// POST de Funcionalidade de Tipo de Usuário
        /// </remarks>
        /// <param name="createDTO">Campos para cadastrar funcionalidade de tipo de usuário</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Funcionalidade de Tipo de Usuário cadastrado</returns>
        /// <response code="200">Funcionalidade de Tipo de Usuário cadastrado com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        [ProducesResponseType(typeof(SuccessResult<ReadUserTypeFeatureDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadUserTypeFeatureDTO>), StatusCodes.Status422UnprocessableEntity)]
        public override Task<IActionResult> CreateAsync([FromBody] CreateUserTypeFeatureDTO createDTO, CancellationToken cancellationToken = default)
        {
            return base.CreateAsync(createDTO, cancellationToken);
        }

        /// <summary>
        /// Atualizar funcionalidade de tipo de usuário 
        /// </summary>
        /// <remarks>
        /// PUT de Funcionalidade de Tipo de Usuário
        /// </remarks>
        /// <param name="id">Id da funcionalidade de tipo de usuário</param>
        /// <param name="updateDTO">Campos para atualizar funcionalidade de tipo de usuário</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Funcionalidade de Tipo de Usuário atualizada</returns>
        /// <response code="200">Funcionalidade de Tipo de Usuário atualizada com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        /// <response code="404">Funcionalidade de Tipo de Usuário não encontrada</response>
        /// <response code="409">Conflito entre ids</response>
        [ProducesResponseType(typeof(SuccessResult<ReadUserTypeFeatureDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadUserTypeFeatureDTO>), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(NotFoundResult<ReadUserTypeFeatureDTO>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ConflictResult<ReadUserTypeFeatureDTO>), StatusCodes.Status409Conflict)]
        public override Task<IActionResult> UpdateAsync([FromRoute] ulong id, [FromBody] UpdateUserTypeFeatureDTO updateDTO, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(id, updateDTO, cancellationToken);
        }

        /// <summary>
        /// Habilitar funcionalidade de tipo de usuário 
        /// </summary>
        /// <remarks>
        /// PUT para habilitar funcionalidade de tipo de usuário 
        /// </remarks>
        /// <param name="id">Id da funcionalidade de tipo de usuário</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Funcionalidade de Tipo de Usuário habilitada</returns>
        /// <response code="200">Funcionalidade de Tipo de Usuário habilitada com sucesso</response>
        /// <response code="404">Funcionalidade de Tipo de Usuário não encontrada</response>
        [ProducesResponseType(typeof(SuccessResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<bool>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> EnableAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.EnableAsync(id, cancellationToken);
        }

        /// <summary>
        /// Desabilitar funcionalidade de tipo de usuário 
        /// </summary>
        /// <remarks>
        /// DELETE de Funcionalidade de Tipo de Usuário 
        /// </remarks>
        /// <param name="id">Id da funcionalidade de tipo de usuário</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Funcionalidade de Tipo de Usuário deletada</returns>
        /// <response code="200">Funcionalidade de Tipo de Usuário deletada com sucesso</response>
        /// <response code="404">Funcionalidade de Tipo de Usuário não encontrada</response>
        [ProducesResponseType(typeof(SuccessResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<bool>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> DisableAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.DisableAsync(id, cancellationToken);
        }

        /// <summary>
        /// Obter funcionalidades de tipos de usuários paginados e filtrados
        /// </summary>
        /// <remarks>
        /// GET de Funcionalidades de Tipos de Usuários
        /// </remarks>
        /// <param name="filter">Filtros para aplicar</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Funcionalidades de Tipos de Usuários paginados e filtrados</returns>
        /// <response code="200">Funcionalidades de Tipos de Usuários paginados e filtrados com sucesso</response>
        [ProducesResponseType(typeof(SuccessResult<Pagination<ReadUserTypeFeatureDTO>>), StatusCodes.Status200OK)]
        public override Task<IActionResult> GetPaginedAsync([FromQuery] BaseFilter filter, CancellationToken cancellationToken = default)
        {
            return base.GetPaginedAsync(filter, cancellationToken);
        }

        /// <summary>
        /// Obter funcionalidade de tipo de usuário por id
        /// </summary>
        /// <remarks>
        /// GET pelo id de funcionalidade de tipo de usuário
        /// </remarks>
        /// <param name="id">Id da funcionalidade de tipo de usuário</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Funcionalidade de Tipo de Usuário encontrada</returns>
        /// <response code="200">Funcionalidade de Tipo de Usuário encontrada com sucesso</response>
        /// <response code="404">Funcionalidade de Tipo de Usuário não encontrada</response>
        [ProducesResponseType(typeof(SuccessResult<ReadUserTypeFeatureDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<ReadUserTypeFeatureDTO>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> GetByIdAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }
    }
}
