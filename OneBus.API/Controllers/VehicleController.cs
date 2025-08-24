using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneBus.API.Extensions;
using OneBus.Application.DTOs.Vehicle;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Commons;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Filters;
using Swashbuckle.AspNetCore.Annotations;

namespace OneBus.API.Controllers
{
    [Route("api/v1/vehicles")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    [SwaggerTag("Controlador responsável por gerenciar Veículos")]
    public class VehicleController
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        /// <summary>
        /// Cadastrar novo veículo 
        /// </summary>
        /// <remarks>
        /// POST de Veículo
        /// </remarks>
        /// <param name="createDTO">Campos para cadastrar veículo</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Veículo cadastrado</returns>
        /// <response code="200">Veículo cadastrado com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        [HttpPost]
        [ProducesResponseType(typeof(SuccessResult<ReadVehicleDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadVehicleDTO>), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateVehicleDTO createDTO, CancellationToken cancellationToken = default)
        {
            return (await _vehicleService.CreateAsync(createDTO, cancellationToken)).ToActionResult();
        }

        /// <summary>
        /// Atualizar veículo 
        /// </summary>
        /// <remarks>
        /// PUT de Veículo
        /// </remarks>
        /// <param name="id">Id do veículo</param>
        /// <param name="updateDTO">Campos para atualizar veículo</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Veículo atualizado</returns>
        /// <response code="200">Veículo atualizado com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        /// <response code="404">Veículo não encontrado</response>
        /// <response code="409">Conflito entre ids</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(SuccessResult<ReadVehicleDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadVehicleDTO>), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(NotFoundResult<ReadVehicleDTO>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ConflictResult<ReadVehicleDTO>), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdateAsync([FromRoute] long id, [FromBody] UpdateVehicleDTO updateDTO, CancellationToken cancellationToken = default)
        {
            if (id != updateDTO.Id)
                return ConflictResult<ReadVehicleDTO>.Create(ErrorUtils.IdConflict()).ToActionResult();

            return (await _vehicleService.UpdateAsync(updateDTO, cancellationToken)).ToActionResult();
        }

        /// <summary>
        /// Deletar veículo 
        /// </summary>
        /// <remarks>
        /// DELETE de Veículo 
        /// </remarks>
        /// <param name="id">Id do veículo</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Veículo deletado</returns>
        /// <response code="200">Veículo deletado com sucesso</response>
        /// <response code="404">Veículo não encontrado</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(SuccessResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return (await _vehicleService.DeleteAsync(id, cancellationToken)).ToActionResult();
        }

        /// <summary>
        /// Obter veículos paginados e filtrados
        /// </summary>
        /// <remarks>
        /// GET de Veículos
        /// </remarks>
        /// <param name="filter">Filtros para aplicar</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Veículos paginados e filtrados</returns>
        /// <response code="200">Veículos paginados e filtrados com sucesso</response>
        [HttpGet]
        [ProducesResponseType(typeof(SuccessResult<Pagination<ReadVehicleDTO>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPaginedAsync([FromQuery] BaseFilter filter, CancellationToken cancellationToken = default)
        {
            return (await _vehicleService.GetPaginedAsync(filter, cancellationToken)).ToActionResult();
        }

        /// <summary>
        /// Obter veículo por id
        /// </summary>
        /// <remarks>
        /// GET pelo id de veículo
        /// </remarks>
        /// <param name="id">Id do veículo</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Veículo encontrado</returns>
        /// <response code="200">Veículo encontrado com sucesso</response>
        /// <response code="404">Veículo não encontrado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SuccessResult<ReadVehicleDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<ReadVehicleDTO>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return (await _vehicleService.GetByIdAsync(id, cancellationToken)).ToActionResult();
        }
    }
}
