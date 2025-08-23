using Microsoft.AspNetCore.Mvc;
using OneBus.Application.DTOs.Line;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Commons;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using Swashbuckle.AspNetCore.Annotations;

namespace OneBus.API.Controllers
{
    [SwaggerTag("Controlador responsável por gerenciar Linhas")]
    public class LineController : BaseController<Line, CreateLineDTO, ReadLineDTO, UpdateLineDTO, BaseFilter>
    {
        public LineController(
            IBaseService<Line, CreateLineDTO, ReadLineDTO, UpdateLineDTO, BaseFilter> baseService)
            : base(baseService)
        {
        }

        /// <summary>
        /// Cadastrar nova linha 
        /// </summary>
        /// <remarks>
        /// POST de Linha
        /// </remarks>
        /// <param name="createDTO">Campos para cadastrar linha</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Linha cadastrada</returns>
        /// <response code="200">Linha cadastrada com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        [ProducesResponseType(typeof(SuccessResult<ReadLineDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadLineDTO>), StatusCodes.Status422UnprocessableEntity)]
        public override Task<IActionResult> CreateAsync([FromBody] CreateLineDTO createDTO, CancellationToken cancellationToken = default)
        {
            return base.CreateAsync(createDTO, cancellationToken);
        }

        /// <summary>
        /// Atualizar linha 
        /// </summary>
        /// <remarks>
        /// PUT de Linha
        /// </remarks>
        /// <param name="id">Id da linha</param>
        /// <param name="updateDTO">Campos para atualizar linha</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Linha atualizada</returns>
        /// <response code="200">Linha atualizada com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        /// <response code="404">Linha não encontrada</response>
        /// <response code="409">Conflito entre ids</response>
        [ProducesResponseType(typeof(SuccessResult<ReadLineDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadLineDTO>), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(NotFoundResult<ReadLineDTO>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ConflictResult<ReadLineDTO>), StatusCodes.Status409Conflict)]
        public override Task<IActionResult> UpdateAsync([FromRoute] ulong id, [FromBody] UpdateLineDTO updateDTO, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(id, updateDTO, cancellationToken);
        }

        /// <summary>
        /// Deletar linha
        /// </summary>
        /// <remarks>
        /// DELETE de Linha 
        /// </remarks>
        /// <param name="id">Id da linha</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Linha deletada</returns>
        /// <response code="200">Linha deletada com sucesso</response>
        /// <response code="404">Linha não encontrada</response>
        [ProducesResponseType(typeof(SuccessResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<bool>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> DeleteAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync(id, cancellationToken);
        }

        /// <summary>
        /// Obter linhas paginadas e filtradas
        /// </summary>
        /// <remarks>
        /// GET de Linhas
        /// </remarks>
        /// <param name="filter">Filtros para aplicar</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Linhas paginadas e filtradas</returns>
        /// <response code="200">Linhas paginadas e filtradas com sucesso</response>
        [ProducesResponseType(typeof(SuccessResult<Pagination<ReadLineDTO>>), StatusCodes.Status200OK)]
        public override Task<IActionResult> GetPaginedAsync([FromQuery] BaseFilter filter, CancellationToken cancellationToken = default)
        {
            return base.GetPaginedAsync(filter, cancellationToken);
        }

        /// <summary>
        /// Obter linha por id
        /// </summary>
        /// <remarks>
        /// GET pelo id da linha
        /// </remarks>
        /// <param name="id">Id da linha</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Linha encontrada</returns>
        /// <response code="200">Linha encontrada com sucesso</response>
        /// <response code="404">Linha não encontrada</response>
        [ProducesResponseType(typeof(SuccessResult<ReadLineDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<ReadLineDTO>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> GetByIdAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }
    }
}
