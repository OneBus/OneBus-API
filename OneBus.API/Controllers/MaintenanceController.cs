using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneBus.API.Extensions;
using OneBus.Application.DTOs.Maintenance;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Commons;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Filters;
using Swashbuckle.AspNetCore.Annotations;

namespace OneBus.API.Controllers
{
    [Route("api/v1/maintenances")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    [SwaggerTag("Controlador responsável por gerenciar Manutenções")]
    public class MaintenanceController
    {
        private readonly IMaintenanceService _maintenanceService;

        public MaintenanceController(IMaintenanceService maintenanceService)
        {
            _maintenanceService = maintenanceService;
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
        [HttpPost]
        [ProducesResponseType(typeof(SuccessResult<ReadMaintenanceDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadMaintenanceDTO>), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateMaintenanceDTO createDTO, CancellationToken cancellationToken = default)
        {
            return (await _maintenanceService.CreateAsync(createDTO, cancellationToken)).ToActionResult();
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
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(SuccessResult<ReadMaintenanceDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadMaintenanceDTO>), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(NotFoundResult<ReadMaintenanceDTO>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ConflictResult<ReadMaintenanceDTO>), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdateAsync([FromRoute] long id, [FromBody] UpdateMaintenanceDTO updateDTO, CancellationToken cancellationToken = default)
        {
            if (id != updateDTO.Id)
                return ConflictResult<ReadMaintenanceDTO>.Create(ErrorUtils.IdConflict()).ToActionResult();

            return (await _maintenanceService.UpdateAsync(updateDTO, cancellationToken)).ToActionResult();
        }

        /// <summary>
        /// Deletar manutenção
        /// </summary>
        /// <remarks>
        /// DELETE de Manutenção 
        /// </remarks>
        /// <param name="id">Id da manutenção</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Manutenção deletada</returns>
        /// <response code="200">Manutenção deletada com sucesso</response>
        /// <response code="404">Manutenção não encontrada</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(SuccessResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return (await _maintenanceService.DeleteAsync(id, cancellationToken)).ToActionResult();
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
        [HttpGet]
        [ProducesResponseType(typeof(SuccessResult<Pagination<ReadMaintenanceDTO>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPaginedAsync([FromQuery] MaintenanceFilter filter, CancellationToken cancellationToken = default)
        {
            return (await _maintenanceService.GetPaginedAsync(filter,
                DbQueryOptions.Create(["Vehicle"]),
                cancellationToken)).ToActionResult();
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
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SuccessResult<ReadMaintenanceDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<ReadMaintenanceDTO>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return (await _maintenanceService.GetByIdAsync(id,
                 DbQueryOptions.Create(["Vehicle"]),
                 cancellationToken)).ToActionResult();
        }

        /// <summary>
        /// Listar tipos de setores
        /// </summary>
        /// <remarks>
        /// GET de tipos de setores
        /// </remarks>
        /// <returns>Tipos de Setores disponíveis</returns>
        /// <response code="200">Setores retornados com sucesso</response>
        [HttpGet("sectors")]
        [ProducesResponseType(typeof(SuccessResult<IEnumerable<ReadSectorDTO>>), StatusCodes.Status200OK)]
        public IActionResult GetSectors()
        {
            return _maintenanceService.GetSectors().ToActionResult();
        }
    }
}
