using Microsoft.AspNetCore.Mvc;
using OneBus.Application.DTOs.Vehicle;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Commons;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using Swashbuckle.AspNetCore.Annotations;

namespace OneBus.API.Controllers
{
    [SwaggerTag("Controlador responsável por gerenciar Veículos")]
    public class VehicleController : BaseController<Vehicle, CreateVehicleDTO, ReadVehicleDTO, UpdateVehicleDTO, BaseFilter>
    {
        public VehicleController(
            IBaseService<Vehicle, CreateVehicleDTO, ReadVehicleDTO, UpdateVehicleDTO, BaseFilter> baseService) 
            : base(baseService)
        {
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
        [ProducesResponseType(typeof(SuccessResult<ReadVehicleDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadVehicleDTO>), StatusCodes.Status422UnprocessableEntity)]
        public override Task<IActionResult> CreateAsync([FromBody] CreateVehicleDTO createDTO, CancellationToken cancellationToken = default)
        {
            return base.CreateAsync(createDTO, cancellationToken);
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
        [ProducesResponseType(typeof(SuccessResult<ReadVehicleDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadVehicleDTO>), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(NotFoundResult<ReadVehicleDTO>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ConflictResult<ReadVehicleDTO>), StatusCodes.Status409Conflict)]
        public override Task<IActionResult> UpdateAsync([FromRoute] ulong id, [FromBody] UpdateVehicleDTO updateDTO, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(id, updateDTO, cancellationToken);
        }

        /// <summary>
        /// Habilitar veículo 
        /// </summary>
        /// <remarks>
        /// PUT para habilitar veículo 
        /// </remarks>
        /// <param name="id">Id do veículo</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Veículo habilitado</returns>
        /// <response code="200">Veículo habilitado com sucesso</response>
        /// <response code="404">Veículo não encontrado</response>
        [ProducesResponseType(typeof(SuccessResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<bool>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> EnableAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.EnableAsync(id, cancellationToken);
        }

        /// <summary>
        /// Desabilitar veículo 
        /// </summary>
        /// <remarks>
        /// DELETE de Veículo 
        /// </remarks>
        /// <param name="id">Id do veículo</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Veículo deletado</returns>
        /// <response code="200">Veículo deletado com sucesso</response>
        /// <response code="404">Veículo não encontrado</response>
        [ProducesResponseType(typeof(SuccessResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<bool>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> DisableAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.DisableAsync(id, cancellationToken);
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
        [ProducesResponseType(typeof(SuccessResult<Pagination<ReadVehicleDTO>>), StatusCodes.Status200OK)]
        public override Task<IActionResult> GetPaginedAsync([FromQuery] BaseFilter filter, CancellationToken cancellationToken = default)
        {
            return base.GetPaginedAsync(filter, cancellationToken);
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
        [ProducesResponseType(typeof(SuccessResult<ReadVehicleDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<ReadVehicleDTO>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> GetByIdAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }
    }
}
