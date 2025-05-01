using Microsoft.AspNetCore.Mvc;
using OneBus.Application.DTOs.Stop;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Commons;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using Swashbuckle.AspNetCore.Annotations;

namespace OneBus.API.Controllers
{
    [SwaggerTag("Controlador responsável por gerenciar Paradas")]
    public class StopController : BaseController<Stop, CreateStopDTO, ReadStopDTO, UpdateStopDTO, BaseFilter>
    {
        public StopController(
            IBaseService<Stop, CreateStopDTO, ReadStopDTO, UpdateStopDTO, BaseFilter> baseService) 
            : base(baseService)
        {
        }

        /// <summary>
        /// Cadastrar nova parada 
        /// </summary>
        /// <remarks>
        /// POST de Parada
        /// </remarks>
        /// <param name="createDTO">Campos para cadastrar parada</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Parada cadastrada</returns>
        /// <response code="200">Parada cadastrada com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        [ProducesResponseType(typeof(SuccessResult<ReadStopDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadStopDTO>), StatusCodes.Status422UnprocessableEntity)]
        public override Task<IActionResult> CreateAsync([FromBody] CreateStopDTO createDTO, CancellationToken cancellationToken = default)
        {
            return base.CreateAsync(createDTO, cancellationToken);
        }

        /// <summary>
        /// Atualizar parada 
        /// </summary>
        /// <remarks>
        /// PUT de Parada
        /// </remarks>
        /// <param name="id">Id da parada</param>
        /// <param name="updateDTO">Campos para atualizar parada</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Parada atualizada</returns>
        /// <response code="200">Parada atualizada com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        /// <response code="404">Parada não encontrada</response>
        /// <response code="409">Conflito entre ids</response>
        [ProducesResponseType(typeof(SuccessResult<ReadStopDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadStopDTO>), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(NotFoundResult<ReadStopDTO>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ConflictResult<ReadStopDTO>), StatusCodes.Status409Conflict)]
        public override Task<IActionResult> UpdateAsync([FromRoute] ulong id, [FromBody] UpdateStopDTO updateDTO, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(id, updateDTO, cancellationToken);
        }

        /// <summary>
        /// Habilitar parada 
        /// </summary>
        /// <remarks>
        /// PUT para habilitar parada 
        /// </remarks>
        /// <param name="id">Id da parada</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Parada habilitada</returns>
        /// <response code="200">Parada habilitada com sucesso</response>
        /// <response code="404">Parada não encontrada</response>
        [ProducesResponseType(typeof(SuccessResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<bool>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> EnableAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.EnableAsync(id, cancellationToken);
        }

        /// <summary>
        /// Desabilitar parada
        /// </summary>
        /// <remarks>
        /// DELETE de Parada 
        /// </remarks>
        /// <param name="id">Id da parada</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Parada deletada</returns>
        /// <response code="200">Parada deletada com sucesso</response>
        /// <response code="404">Parada não encontrada</response>
        [ProducesResponseType(typeof(SuccessResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<bool>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> DisableAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.DisableAsync(id, cancellationToken);
        }

        /// <summary>
        /// Obter paradas paginadas e filtradas
        /// </summary>
        /// <remarks>
        /// GET de Paradas
        /// </remarks>
        /// <param name="filter">Filtros para aplicar</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Paradas paginadas e filtradas</returns>
        /// <response code="200">Paradas paginadas e filtradas com sucesso</response>
        [ProducesResponseType(typeof(SuccessResult<Pagination<ReadStopDTO>>), StatusCodes.Status200OK)]
        public override Task<IActionResult> GetPaginedAsync([FromQuery] BaseFilter filter, CancellationToken cancellationToken = default)
        {
            return base.GetPaginedAsync(filter, cancellationToken);
        }

        /// <summary>
        /// Obter parada por id
        /// </summary>
        /// <remarks>
        /// GET pelo id da parada
        /// </remarks>
        /// <param name="id">Id da parada</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Parada encontrada</returns>
        /// <response code="200">Parada encontrada com sucesso</response>
        /// <response code="404">Parada não encontrada</response>
        [ProducesResponseType(typeof(SuccessResult<ReadStopDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<ReadStopDTO>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> GetByIdAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }
    }
}
