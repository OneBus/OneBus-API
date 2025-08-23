using Microsoft.AspNetCore.Mvc;
using OneBus.Application.DTOs.VehicleGarage;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Commons;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using Swashbuckle.AspNetCore.Annotations;

namespace OneBus.API.Controllers
{
    [SwaggerTag("Controlador responsável por gerenciar Garagem de Veículos")]
    public class VehicleGarageController : BaseController<VehicleGarage, CreateVehicleGarageDTO, ReadVehicleGarageDTO, UpdateVehicleGarageDTO, BaseFilter>
    {
        public VehicleGarageController(
            IBaseService<VehicleGarage, CreateVehicleGarageDTO, ReadVehicleGarageDTO, UpdateVehicleGarageDTO, BaseFilter> baseService) 
            : base(baseService)
        {
        }

        /// <summary>
        /// Cadastrar nova garagem de veículo 
        /// </summary>
        /// <remarks>
        /// POST de Garagem de Veículo
        /// </remarks>
        /// <param name="createDTO">Campos para cadastrar garagem de veículo</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Garagem de Veículo cadastrada</returns>
        /// <response code="200">Garagem de Veículo cadastrada com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        [ProducesResponseType(typeof(SuccessResult<ReadVehicleGarageDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadVehicleGarageDTO>), StatusCodes.Status422UnprocessableEntity)]
        public override Task<IActionResult> CreateAsync([FromBody] CreateVehicleGarageDTO createDTO, CancellationToken cancellationToken = default)
        {
            return base.CreateAsync(createDTO, cancellationToken);
        }

        /// <summary>
        /// Atualizar garagem de veículo 
        /// </summary>
        /// <remarks>
        /// PUT de Garagem de Veículo
        /// </remarks>
        /// <param name="id">Id da garagem de veículo</param>
        /// <param name="updateDTO">Campos para atualizar garagem de veículo</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Garagem de Veículo atualizada</returns>
        /// <response code="200">Garagem de Veículo atualizada com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        /// <response code="404">Garagem de Veículo não encontrada</response>
        /// <response code="409">Conflito entre ids</response>
        [ProducesResponseType(typeof(SuccessResult<ReadVehicleGarageDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadVehicleGarageDTO>), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(NotFoundResult<ReadVehicleGarageDTO>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ConflictResult<ReadVehicleGarageDTO>), StatusCodes.Status409Conflict)]
        public override Task<IActionResult> UpdateAsync([FromRoute] ulong id, [FromBody] UpdateVehicleGarageDTO updateDTO, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(id, updateDTO, cancellationToken);
        }

        /// <summary>
        /// Deletar garagem de veículo 
        /// </summary>
        /// <remarks>
        /// DELETE de Garagem de Veículo
        /// </remarks>
        /// <param name="id">Id da garagem de veículo</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Garagem de Veículo deletada</returns>
        /// <response code="200">Garagem de Veículo deletada com sucesso</response>
        /// <response code="404">Garagem de Veículo não encontrada</response>
        [ProducesResponseType(typeof(SuccessResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<bool>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> DeleteAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync(id, cancellationToken);
        }

        /// <summary>
        /// Obter garagem de veículos paginadas e filtradas
        /// </summary>
        /// <remarks>
        /// GET de Garagem de Veículos
        /// </remarks>
        /// <param name="filter">Filtros para aplicar</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Garagem de Veículos paginadas e filtradas</returns>
        /// <response code="200">Garagem de Veículos paginadas e filtradas com sucesso</response>
        [ProducesResponseType(typeof(SuccessResult<Pagination<ReadVehicleGarageDTO>>), StatusCodes.Status200OK)]
        public override Task<IActionResult> GetPaginedAsync([FromQuery] BaseFilter filter, CancellationToken cancellationToken = default)
        {
            return base.GetPaginedAsync(filter, cancellationToken);
        }

        /// <summary>
        /// Obter garagem de veículo por id
        /// </summary>
        /// <remarks>
        /// GET pelo id da garagem de veículo
        /// </remarks>
        /// <param name="id">Id da garagem de veículo</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Garagem de Veículo encontrada</returns>
        /// <response code="200">Garagem de Veículo encontrada com sucesso</response>
        /// <response code="404">Garagem de Veículo não encontrada</response>
        [ProducesResponseType(typeof(SuccessResult<ReadVehicleGarageDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<ReadVehicleGarageDTO>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> GetByIdAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }
    }
}
