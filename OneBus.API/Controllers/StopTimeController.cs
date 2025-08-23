using Microsoft.AspNetCore.Mvc;
using OneBus.Application.DTOs.StopTime;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Commons;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using Swashbuckle.AspNetCore.Annotations;

namespace OneBus.API.Controllers
{
    [SwaggerTag("Controlador responsável por gerenciar Horários da Parada")]
    public class StopTimeController : BaseController<StopTime, CreateStopTimeDTO, ReadStopTimeDTO, UpdateStopTimeDTO, BaseFilter>
    {
        public StopTimeController(
            IBaseService<StopTime, CreateStopTimeDTO, ReadStopTimeDTO, UpdateStopTimeDTO, BaseFilter> baseService) 
            : base(baseService)
        {
        }

        /// <summary>
        /// Cadastrar novo horário de parada 
        /// </summary>
        /// <remarks>
        /// POST de Horário de Parada
        /// </remarks>
        /// <param name="createDTO">Campos para cadastrar horário de parada</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Horário de Parada cadastrado</returns>
        /// <response code="200">Horário de Parada cadastrado com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        [ProducesResponseType(typeof(SuccessResult<ReadStopTimeDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadStopTimeDTO>), StatusCodes.Status422UnprocessableEntity)]
        public override Task<IActionResult> CreateAsync([FromBody] CreateStopTimeDTO createDTO, CancellationToken cancellationToken = default)
        {
            return base.CreateAsync(createDTO, cancellationToken);
        }

        /// <summary>
        /// Atualizar horário de parada 
        /// </summary>
        /// <remarks>
        /// PUT de Horário de Parada
        /// </remarks>
        /// <param name="id">Id do horário de parada</param>
        /// <param name="updateDTO">Campos para atualizar horário de parada</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Horário de Parada atualizado</returns>
        /// <response code="200">Horário de Parada atualizado com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        /// <response code="404">Horário de Parada não encontrado</response>
        /// <response code="409">Conflito entre ids</response>
        [ProducesResponseType(typeof(SuccessResult<ReadStopTimeDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadStopTimeDTO>), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(NotFoundResult<ReadStopTimeDTO>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ConflictResult<ReadStopTimeDTO>), StatusCodes.Status409Conflict)]
        public override Task<IActionResult> UpdateAsync([FromRoute] ulong id, [FromBody] UpdateStopTimeDTO updateDTO, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(id, updateDTO, cancellationToken);
        }        

        /// <summary>
        /// Deletar horário de parada
        /// </summary>
        /// <remarks>
        /// DELETE de Horário de Parada 
        /// </remarks>
        /// <param name="id">Id do horário de parada</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Horário de Parada deletado</returns>
        /// <response code="200">Horário de Parada deletado com sucesso</response>
        /// <response code="404">Horário de Parada não encontrado</response>
        [ProducesResponseType(typeof(SuccessResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<bool>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> DeleteAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync(id, cancellationToken);
        }

        /// <summary>
        /// Obter horários de parada paginados e filtrados
        /// </summary>
        /// <remarks>
        /// GET de Horários de Parada
        /// </remarks>
        /// <param name="filter">Filtros para aplicar</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Horários de Parada paginados e filtrados</returns>
        /// <response code="200">Horários de Parada paginados e filtrados com sucesso</response>
        [ProducesResponseType(typeof(SuccessResult<Pagination<ReadStopTimeDTO>>), StatusCodes.Status200OK)]
        public override Task<IActionResult> GetPaginedAsync([FromQuery] BaseFilter filter, CancellationToken cancellationToken = default)
        {
            return base.GetPaginedAsync(filter, cancellationToken);
        }

        /// <summary>
        /// Obter horário de parada por id
        /// </summary>
        /// <remarks>
        /// GET pelo id do horário de parada
        /// </remarks>
        /// <param name="id">Id do horário de parada</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Horário de Parada encontrado</returns>
        /// <response code="200">Horário de Parada encontrado com sucesso</response>
        /// <response code="404">Horário de Parada não encontrado</response>
        [ProducesResponseType(typeof(SuccessResult<ReadStopTimeDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<ReadStopTimeDTO>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> GetByIdAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }
    }
}
