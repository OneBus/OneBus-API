using Microsoft.AspNetCore.Mvc;
using OneBus.Application.DTOs.VehicleOperation;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Commons;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using Swashbuckle.AspNetCore.Annotations;

namespace OneBus.API.Controllers
{
    [SwaggerTag("Controlador responsável por gerenciar Operações de Veículos")]
    public class VehicleOperationController : BaseController<VehicleOperation, CreateVehicleOperationDTO, ReadVehicleOperationDTO, UpdateVehicleOperationDTO, BaseFilter>
    {
        public VehicleOperationController(
            IBaseService<VehicleOperation, CreateVehicleOperationDTO, ReadVehicleOperationDTO, UpdateVehicleOperationDTO, BaseFilter> baseService) 
            : base(baseService)
        {
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
        [ProducesResponseType(typeof(SuccessResult<ReadVehicleOperationDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadVehicleOperationDTO>), StatusCodes.Status422UnprocessableEntity)]
        public override Task<IActionResult> CreateAsync([FromBody] CreateVehicleOperationDTO createDTO, CancellationToken cancellationToken = default)
        {
            return base.CreateAsync(createDTO, cancellationToken);
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
        [ProducesResponseType(typeof(SuccessResult<ReadVehicleOperationDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadVehicleOperationDTO>), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(NotFoundResult<ReadVehicleOperationDTO>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ConflictResult<ReadVehicleOperationDTO>), StatusCodes.Status409Conflict)]
        public override Task<IActionResult> UpdateAsync([FromRoute] ulong id, [FromBody] UpdateVehicleOperationDTO updateDTO, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(id, updateDTO, cancellationToken);
        }

        /// <summary>
        /// Habilitar operação de veículo 
        /// </summary>
        /// <remarks>
        /// PUT para habilitar operação de veículo 
        /// </remarks>
        /// <param name="id">Id da operação de veículo</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Operação de Veículo habilitada</returns>
        /// <response code="200">Operação de Veículo habilitada com sucesso</response>
        /// <response code="404">Operação de Veículo não encontrada</response>
        [ProducesResponseType(typeof(SuccessResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<bool>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> EnableAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.EnableAsync(id, cancellationToken);
        }

        /// <summary>
        /// Desabilitar operação de veículo 
        /// </summary>
        /// <remarks>
        /// DELETE de Operação de Veículo 
        /// </remarks>
        /// <param name="id">Id da operação de veículo</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Operação de Veículo deletada</returns>
        /// <response code="200">Operação de Veículo deletada com sucesso</response>
        /// <response code="404">Operação de Veículo não encontrada</response>
        [ProducesResponseType(typeof(SuccessResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<bool>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> DisableAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.DisableAsync(id, cancellationToken);
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
        [ProducesResponseType(typeof(SuccessResult<Pagination<ReadVehicleOperationDTO>>), StatusCodes.Status200OK)]
        public override Task<IActionResult> GetPaginedAsync([FromQuery] BaseFilter filter, CancellationToken cancellationToken = default)
        {
            return base.GetPaginedAsync(filter, cancellationToken);
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
        [ProducesResponseType(typeof(SuccessResult<ReadVehicleOperationDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<ReadVehicleOperationDTO>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> GetByIdAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }
    }
}
