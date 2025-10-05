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
            return (await _vehicleService.CreateAsync(createDTO, cancellationToken: cancellationToken)).ToActionResult();
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
        public async Task<IActionResult> GetPaginedAsync([FromQuery] VehicleFilter filter, CancellationToken cancellationToken = default)
        {
            return (await _vehicleService.GetPaginedAsync(filter, cancellationToken: cancellationToken)).ToActionResult();
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
            return (await _vehicleService.GetByIdAsync(id, cancellationToken: cancellationToken)).ToActionResult();
        }

        /// <summary>
        /// Listar status
        /// </summary>
        /// <remarks>
        /// GET de status
        /// </remarks>
        /// <returns>Status disponíveis</returns>
        /// <response code="200">Status retornados com sucesso</response>
        [HttpGet("status")]
        [ProducesResponseType(typeof(SuccessResult<IEnumerable<ReadVehicleStatusDTO>>), StatusCodes.Status200OK)]
        public IActionResult GetStatus()
        {
            return _vehicleService.GetStatus().ToActionResult();
        }

        /// <summary>
        /// Listar marcas
        /// </summary>
        /// <remarks>
        /// GET de marcas
        /// </remarks>
        /// <returns>Marcas disponíveis</returns>
        /// <response code="200">Marcas retornadas com sucesso</response>
        [HttpGet("brands")]
        [ProducesResponseType(typeof(SuccessResult<IEnumerable<ReadBrandDTO>>), StatusCodes.Status200OK)]
        public IActionResult GetBrands()
        {
            return _vehicleService.GetBrands().ToActionResult();
        }

        /// <summary>
        /// Listar marcas de chassis
        /// </summary>
        /// <remarks>
        /// GET de marcas de chassis
        /// </remarks>
        /// <returns>Marcas de chassis disponíveis</returns>
        /// <response code="200">Marcas de chassis retornadas com sucesso</response>
        [HttpGet("chassisBrands")]
        [ProducesResponseType(typeof(SuccessResult<IEnumerable<ReadBusChassisBrandDTO>>), StatusCodes.Status200OK)]
        public IActionResult GetBusChassisBrands()
        {
            return _vehicleService.GetBusChassisBrands().ToActionResult();
        }

        /// <summary>
        /// Listar tipos de serviço
        /// </summary>
        /// <remarks>
        /// GET de tipos de serviço
        /// </remarks>
        /// <returns>Tipos de serviço disponíveis</returns>
        /// <response code="200">Tipos de serviço retornados com sucesso</response>
        [HttpGet("serviceTypes")]
        [ProducesResponseType(typeof(SuccessResult<IEnumerable<ReadBusServiceTypeDTO>>), StatusCodes.Status200OK)]
        public IActionResult GetBusServiceTypes()
        {
            return _vehicleService.GetBusServiceTypes().ToActionResult();
        }

        /// <summary>
        /// Listar cores
        /// </summary>
        /// <remarks>
        /// GET de cores
        /// </remarks>
        /// <returns>Cores disponíveis</returns>
        /// <response code="200">Cores retornadas com sucesso</response>
        [HttpGet("colors")]
        [ProducesResponseType(typeof(SuccessResult<IEnumerable<ReadColorDTO>>), StatusCodes.Status200OK)]
        public IActionResult GetColors()
        {
            return _vehicleService.GetColors().ToActionResult();
        }

        /// <summary>
        /// Listar tipos de combustíveis
        /// </summary>
        /// <remarks>
        /// GET de tipos de combustíveis
        /// </remarks>
        /// <returns>Tipos de combustíveis disponíveis</returns>
        /// <response code="200">Tipos de combustíveis retornados com sucesso</response>
        [HttpGet("fuelTypes")]
        [ProducesResponseType(typeof(SuccessResult<IEnumerable<ReadFuelTypeDTO>>), StatusCodes.Status200OK)]
        public IActionResult GetFuelTypes()
        {
            return _vehicleService.GetFuelTypes().ToActionResult();
        }

        /// <summary>
        /// Listar tipos de transmissão
        /// </summary>
        /// <remarks>
        /// GET de tipos de transmissão
        /// </remarks>
        /// <returns>Tipos de transmissão disponíveis</returns>
        /// <response code="200">Tipos de transmissão retornados com sucesso</response>
        [HttpGet("transmissionTypes")]
        [ProducesResponseType(typeof(SuccessResult<IEnumerable<ReadTransmissionTypeDTO>>), StatusCodes.Status200OK)]
        public IActionResult GetTransmissionTypes()
        {
            return _vehicleService.GetTransmissionTypes().ToActionResult();
        }

        /// <summary>
        /// Listar tipos de veículo
        /// </summary>
        /// <remarks>
        /// GET de tipos de veículo
        /// </remarks>
        /// <returns>Tipos de veículo disponíveis</returns>
        /// <response code="200">Tipos de veículo retornados com sucesso</response>
        [HttpGet("types")]
        [ProducesResponseType(typeof(SuccessResult<IEnumerable<ReadTypeDTO>>), StatusCodes.Status200OK)]
        public IActionResult GetVehicleTypes()
        {
            return _vehicleService.GetVehicleTypes().ToActionResult();
        }
    }
}
