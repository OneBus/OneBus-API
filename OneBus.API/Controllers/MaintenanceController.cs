using Microsoft.AspNetCore.Mvc;
using OneBus.Application.DTOs.Maintenance;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Commons;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using Swashbuckle.AspNetCore.Annotations;

namespace OneBus.API.Controllers
{
    [SwaggerTag("Controlador responsável por gerenciar Manutenções")]
    public class MaintenanceController : BaseController<Maintenance, CreateMaintenanceDTO, ReadMaintenanceDTO, UpdateMaintenanceDTO, BaseFilter>
    {
        public MaintenanceController(
            IBaseService<Maintenance, CreateMaintenanceDTO, ReadMaintenanceDTO, UpdateMaintenanceDTO, BaseFilter> baseService) 
            : base(baseService)
        {
        }

        /// <summary>
        /// Cadastrar nova manutenção 
        /// </summary>
        /// <remarks>
        /// POST de Manutenção
        /// </remarks>
        /// <param name="createDTO">Campos para cadastrar manutenção</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Manutenção cadastrada</returns>
        /// <response code="200">Manutenção cadastrada com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        [ProducesResponseType(typeof(SuccessResult<ReadMaintenanceDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadMaintenanceDTO>), StatusCodes.Status422UnprocessableEntity)]
        public override Task<IActionResult> CreateAsync([FromBody] CreateMaintenanceDTO createDTO, CancellationToken cancellationToken = default)
        {
            return base.CreateAsync(createDTO, cancellationToken);
        }

        /// <summary>
        /// Atualizar manutenção 
        /// </summary>
        /// <remarks>
        /// PUT de Manutenção
        /// </remarks>
        /// <param name="id">Id da manutenção</param>
        /// <param name="updateDTO">Campos para atualizar manutenção</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Manutenção atualizada</returns>
        /// <response code="200">Manutenção atualizada com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        /// <response code="404">Manutenção não encontrada</response>
        /// <response code="409">Conflito entre ids</response>
        [ProducesResponseType(typeof(SuccessResult<ReadMaintenanceDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadMaintenanceDTO>), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(NotFoundResult<ReadMaintenanceDTO>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ConflictResult<ReadMaintenanceDTO>), StatusCodes.Status409Conflict)]
        public override Task<IActionResult> UpdateAsync([FromRoute] ulong id, [FromBody] UpdateMaintenanceDTO updateDTO, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(id, updateDTO, cancellationToken);
        }

        /// <summary>
        /// Habilitar manutenção 
        /// </summary>
        /// <remarks>
        /// PUT para habilitar manutenção 
        /// </remarks>
        /// <param name="id">Id da manutenção</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Manutenção habilitada</returns>
        /// <response code="200">Manutenção habilitada com sucesso</response>
        /// <response code="404">Manutenção não encontrada</response>
        [ProducesResponseType(typeof(SuccessResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<bool>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> EnableAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.EnableAsync(id, cancellationToken);
        }

        /// <summary>
        /// Desabilitar manutenção
        /// </summary>
        /// <remarks>
        /// DELETE de Manutenção 
        /// </remarks>
        /// <param name="id">Id da manutenção</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Manutenção deletada</returns>
        /// <response code="200">Manutenção deletada com sucesso</response>
        /// <response code="404">Manutenção não encontrada</response>
        [ProducesResponseType(typeof(SuccessResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<bool>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> DisableAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.DisableAsync(id, cancellationToken);
        }

        /// <summary>
        /// Obter manutenções paginadas e filtradas
        /// </summary>
        /// <remarks>
        /// GET de Manutenções
        /// </remarks>
        /// <param name="filter">Filtros para aplicar</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Manutenções paginadas e filtradas</returns>
        /// <response code="200">Manutenções paginadas e filtradas com sucesso</response>
        [ProducesResponseType(typeof(SuccessResult<Pagination<ReadMaintenanceDTO>>), StatusCodes.Status200OK)]
        public override Task<IActionResult> GetPaginedAsync([FromQuery] BaseFilter filter, CancellationToken cancellationToken = default)
        {
            return base.GetPaginedAsync(filter, cancellationToken);
        }

        /// <summary>
        /// Obter manutenção por id
        /// </summary>
        /// <remarks>
        /// GET pelo id da manutenção
        /// </remarks>
        /// <param name="id">Id da manutenção</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Manutenção encontrada</returns>
        /// <response code="200">Manutenção encontrada com sucesso</response>
        /// <response code="404">Manutenção não encontrada</response>
        [ProducesResponseType(typeof(SuccessResult<ReadMaintenanceDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<ReadMaintenanceDTO>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> GetByIdAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }
    }
}
