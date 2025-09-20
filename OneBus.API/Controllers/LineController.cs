using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneBus.API.Extensions;
using OneBus.Application.DTOs.Line;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Commons;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Filters;
using Swashbuckle.AspNetCore.Annotations;

namespace OneBus.API.Controllers
{
    [NonController]
    [Route("api/v1/lines")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    [SwaggerTag("Controlador responsável por gerenciar Linhas")]
    public class LineController
    {
        private readonly ILineService _lineService;

        public LineController(ILineService lineService)
        {
            _lineService = lineService;
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
        [HttpPost]
        [ProducesResponseType(typeof(SuccessResult<ReadLineDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadLineDTO>), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateLineDTO createDTO, CancellationToken cancellationToken = default)
        {
            return (await _lineService.CreateAsync(createDTO, cancellationToken)).ToActionResult();
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
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(SuccessResult<ReadLineDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadLineDTO>), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(NotFoundResult<ReadLineDTO>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ConflictResult<ReadLineDTO>), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdateAsync([FromRoute] long id, [FromBody] UpdateLineDTO updateDTO, CancellationToken cancellationToken = default)
        {
            if (id != updateDTO.Id)
                return ConflictResult<ReadLineDTO>.Create(ErrorUtils.IdConflict()).ToActionResult();

            return (await _lineService.UpdateAsync(updateDTO, cancellationToken)).ToActionResult();
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
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(SuccessResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return (await _lineService.DeleteAsync(id, cancellationToken)).ToActionResult();
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
        [HttpGet]
        [ProducesResponseType(typeof(SuccessResult<Pagination<ReadLineDTO>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPaginedAsync([FromQuery] BaseFilter filter, CancellationToken cancellationToken = default)
        {
            return (await _lineService.GetPaginedAsync(filter, cancellationToken: cancellationToken)).ToActionResult();
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
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SuccessResult<ReadLineDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<ReadLineDTO>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return (await _lineService.GetByIdAsync(id, cancellationToken: cancellationToken)).ToActionResult();
        }
    }
}
