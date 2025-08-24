using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneBus.API.Extensions;
using OneBus.Application.DTOs.VehicleOperation;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Commons;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Filters;
using Swashbuckle.AspNetCore.Annotations;

namespace OneBus.API.Controllers
{
    [NonController]
    [Route("api/v1/vehiclesOperations")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    [SwaggerTag("Controlador responsável por gerenciar Operações de Veículos")]
    public class VehicleOperationController
    {
        private readonly IVehicleOperationService _vehicleOperationService;

        public VehicleOperationController(IVehicleOperationService vehicleOperationService)
        {
            _vehicleOperationService = vehicleOperationService;
        }

        /// <summary>
        /// Cadastrar nova operação de veículo 
        /// </summary>
        /// <remarks>
        /// POST de Operação de Veículo
        /// </remarks>
        /// <param name="createDTO">Campos para cadastrar operação de veículo</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Operação de Veículo cadastrada</returns>
        /// <response code="200">Operação de Veículo cadastrada com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        [HttpPost]
        [ProducesResponseType(typeof(SuccessResult<ReadVehicleOperationDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadVehicleOperationDTO>), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateVehicleOperationDTO createDTO, CancellationToken cancellationToken = default)
        {
            return (await _vehicleOperationService.CreateAsync(createDTO, cancellationToken)).ToActionResult();
        }

        /// <summary>
        /// Atualizar operação de veículo 
        /// </summary>
        /// <remarks>
        /// PUT de Operação de Veículo
        /// </remarks>
        /// <param name="id">Id da operação de veículo</param>
        /// <param name="updateDTO">Campos para atualizar operação de veículo</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Operação de Veículo atualizada</returns>
        /// <response code="200">Operação de Veículo atualizada com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        /// <response code="404">Operação de Veículo não encontrada</response>
        /// <response code="409">Conflito entre ids</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(SuccessResult<ReadVehicleOperationDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadVehicleOperationDTO>), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(NotFoundResult<ReadVehicleOperationDTO>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ConflictResult<ReadVehicleOperationDTO>), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdateAsync([FromRoute] long id, [FromBody] UpdateVehicleOperationDTO updateDTO, CancellationToken cancellationToken = default)
        {
            if (id != updateDTO.Id)
                return ConflictResult<ReadVehicleOperationDTO>.Create(ErrorUtils.IdConflict()).ToActionResult();

            return (await _vehicleOperationService.UpdateAsync(updateDTO, cancellationToken)).ToActionResult();
        }

        /// <summary>
        /// Deletar operação de veículo 
        /// </summary>
        /// <remarks>
        /// DELETE de Operação de Veículo 
        /// </remarks>
        /// <param name="id">Id da operação de veículo</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Operação de Veículo deletada</returns>
        /// <response code="200">Operação de Veículo deletada com sucesso</response>
        /// <response code="404">Operação de Veículo não encontrada</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(SuccessResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return (await _vehicleOperationService.DeleteAsync(id, cancellationToken)).ToActionResult();
        }

        /// <summary>
        /// Obter operações de veículos paginadas e filtradas
        /// </summary>
        /// <remarks>
        /// GET de Operações de Veículos
        /// </remarks>
        /// <param name="filter">Filtros para aplicar</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Operações de Veículos paginadas e filtradas</returns>
        /// <response code="200">Operações de Veículos paginadas e filtradas com sucesso</response>
        [HttpGet]
        [ProducesResponseType(typeof(SuccessResult<Pagination<ReadVehicleOperationDTO>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPaginedAsync([FromQuery] BaseFilter filter, CancellationToken cancellationToken = default)
        {
            return (await _vehicleOperationService.GetPaginedAsync(filter, cancellationToken)).ToActionResult();
        }

        /// <summary>
        /// Obter operação de veículo por id
        /// </summary>
        /// <remarks>
        /// GET pelo id da operação de veículo
        /// </remarks>
        /// <param name="id">Id da operação de veículo</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Operação de Veículo encontrada</returns>
        /// <response code="200">Operação de Veículo encontrada com sucesso</response>
        /// <response code="404">Operação de Veículo não encontrada</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SuccessResult<ReadVehicleOperationDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<ReadVehicleOperationDTO>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return (await _vehicleOperationService.GetByIdAsync(id, cancellationToken)).ToActionResult();
        }
    }
}
