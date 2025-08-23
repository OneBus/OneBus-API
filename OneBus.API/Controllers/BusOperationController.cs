using Microsoft.AspNetCore.Mvc;
using OneBus.Application.DTOs.BusOperation;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Commons;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using Swashbuckle.AspNetCore.Annotations;

namespace OneBus.API.Controllers
{
    [SwaggerTag("Controlador responsável por gerenciar Operações de Ônibus")]
    public class BusOperationController : BaseController<BusOperation, CreateBusOperationDTO, ReadBusOperationDTO, UpdateBusOperationDTO, BaseFilter>
    {
        public BusOperationController(
            IBaseService<BusOperation, CreateBusOperationDTO, ReadBusOperationDTO, UpdateBusOperationDTO, BaseFilter> baseService) 
            : base(baseService)
        {
        }

        /// <summary>
        /// Cadastrar nova operação de ônibus 
        /// </summary>
        /// <remarks>
        /// POST de Operação de Ônibus
        /// </remarks>
        /// <param name="createDTO">Campos para cadastrar operação de ônibus</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Operação de Ônibus cadastrada</returns>
        /// <response code="200">Operação de Ônibus cadastrada com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        [ProducesResponseType(typeof(SuccessResult<ReadBusOperationDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadBusOperationDTO>), StatusCodes.Status422UnprocessableEntity)]
        public override Task<IActionResult> CreateAsync([FromBody] CreateBusOperationDTO createDTO, CancellationToken cancellationToken = default)
        {
            return base.CreateAsync(createDTO, cancellationToken);
        }

        /// <summary>
        /// Atualizar operação de ônibus 
        /// </summary>
        /// <remarks>
        /// PUT de Operação de Ônibus
        /// </remarks>
        /// <param name="id">Id da operação de ônibus</param>
        /// <param name="updateDTO">Campos para atualizar operação de ônibus</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Operação de Ônibus atualizada</returns>
        /// <response code="200">Operação de Ônibus atualizada com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        /// <response code="404">Operação de Ônibus não encontrada</response>
        /// <response code="409">Conflito entre ids</response>
        [ProducesResponseType(typeof(SuccessResult<ReadBusOperationDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadBusOperationDTO>), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(NotFoundResult<ReadBusOperationDTO>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ConflictResult<ReadBusOperationDTO>), StatusCodes.Status409Conflict)]
        public override Task<IActionResult> UpdateAsync([FromRoute] ulong id, [FromBody] UpdateBusOperationDTO updateDTO, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(id, updateDTO, cancellationToken);
        }      

        /// <summary>
        /// Deletar operação de ônibus 
        /// </summary>
        /// <remarks>
        /// DELETE de Operação de Ônibus 
        /// </remarks>
        /// <param name="id">Id da operação de ônibus</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Operação de Ônibus deletada</returns>
        /// <response code="200">Operação de Ônibus deletada com sucesso</response>
        /// <response code="404">Operação de Ônibus não encontrada</response>
        [ProducesResponseType(typeof(SuccessResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<bool>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> DeleteAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync(id, cancellationToken);
        }

        /// <summary>
        /// Obter operações de ônibus paginadas e filtradas
        /// </summary>
        /// <remarks>
        /// GET de Operações de Ônibus
        /// </remarks>
        /// <param name="filter">Filtros para aplicar</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Operações de Ônibus paginadas e filtradas</returns>
        /// <response code="200">Operações de Ônibus paginadas e filtradas com sucesso</response>
        [ProducesResponseType(typeof(SuccessResult<Pagination<ReadBusOperationDTO>>), StatusCodes.Status200OK)]
        public override Task<IActionResult> GetPaginedAsync([FromQuery] BaseFilter filter, CancellationToken cancellationToken = default)
        {
            return base.GetPaginedAsync(filter, cancellationToken);
        }

        /// <summary>
        /// Obter operação de ônibus por id
        /// </summary>
        /// <remarks>
        /// GET pelo id da operação de ônibus
        /// </remarks>
        /// <param name="id">Id da operação de ônibus</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Operação de Ônibus encontrada</returns>
        /// <response code="200">Operação de Ônibus encontrada com sucesso</response>
        /// <response code="404">Operação de Ônibus não encontrada</response>
        [ProducesResponseType(typeof(SuccessResult<ReadBusOperationDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<ReadBusOperationDTO>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> GetByIdAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }
    }
}
