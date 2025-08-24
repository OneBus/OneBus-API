using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneBus.API.Extensions;
using OneBus.Application.DTOs.LineTime;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Commons;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Filters;
using Swashbuckle.AspNetCore.Annotations;

namespace OneBus.API.Controllers
{
    [NonController]
    [Route("api/v1/linesTimes")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    [SwaggerTag("Controlador responsável por gerenciar Horários da Linha")]
    public class LineTimeController
    {
        private readonly ILineTimeService _lineTimeService;

        public LineTimeController(ILineTimeService lineTimeService)
        {
            _lineTimeService = lineTimeService;
        }

        /// <summary>
        /// Cadastrar novo horário de linha 
        /// </summary>
        /// <remarks>
        /// POST de Horário de Linha
        /// </remarks>
        /// <param name="createDTO">Campos para cadastrar horário de linha</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Horário de Linha cadastrado</returns>
        /// <response code="200">Horário de Linha cadastrado com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        [HttpPost]
        [ProducesResponseType(typeof(SuccessResult<ReadLineTimeDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadLineTimeDTO>), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateLineTimeDTO createDTO, CancellationToken cancellationToken = default)
        {
            return (await _lineTimeService.CreateAsync(createDTO, cancellationToken)).ToActionResult();
        }

        /// <summary>
        /// Atualizar horário de linha 
        /// </summary>
        /// <remarks>
        /// PUT de Horário de Linha
        /// </remarks>
        /// <param name="id">Id do horário de linha</param>
        /// <param name="updateDTO">Campos para atualizar horário de linha</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Horário de Linha atualizado</returns>
        /// <response code="200">Horário de Linha atualizado com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        /// <response code="404">Horário de Linha não encontrado</response>
        /// <response code="409">Conflito entre ids</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(SuccessResult<ReadLineTimeDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadLineTimeDTO>), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(NotFoundResult<ReadLineTimeDTO>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ConflictResult<ReadLineTimeDTO>), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdateAsync([FromRoute] long id, [FromBody] UpdateLineTimeDTO updateDTO, CancellationToken cancellationToken = default)
        {
            if (id != updateDTO.Id)
                return ConflictResult<ReadLineTimeDTO>.Create(ErrorUtils.IdConflict()).ToActionResult();

            return (await _lineTimeService.UpdateAsync(updateDTO, cancellationToken)).ToActionResult();
        }

        /// <summary>
        /// Deletar horário de linha
        /// </summary>
        /// <remarks>
        /// DELETE de Horário de Linha 
        /// </remarks>
        /// <param name="id">Id do horário de linha</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Horário de Linha deletado</returns>
        /// <response code="200">Horário de Linha deletado com sucesso</response>
        /// <response code="404">Horário de Linha não encontrado</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(SuccessResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return (await _lineTimeService.DeleteAsync(id, cancellationToken)).ToActionResult();
        }

        /// <summary>
        /// Obter horários de linha paginados e filtrados
        /// </summary>
        /// <remarks>
        /// GET de Horários de Linha
        /// </remarks>
        /// <param name="filter">Filtros para aplicar</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Horários de Linha paginados e filtrados</returns>
        /// <response code="200">Horários de Linha paginados e filtrados com sucesso</response>
        [HttpGet]
        [ProducesResponseType(typeof(SuccessResult<Pagination<ReadLineTimeDTO>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPaginedAsync([FromQuery] BaseFilter filter, CancellationToken cancellationToken = default)
        {
            return (await _lineTimeService.GetPaginedAsync(filter, cancellationToken)).ToActionResult();
        }

        /// <summary>
        /// Obter horário de linha por id
        /// </summary>
        /// <remarks>
        /// GET pelo id do horário de linha
        /// </remarks>
        /// <param name="id">Id do horário de linha</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Horário de Linha encontrado</returns>
        /// <response code="200">Horário de Linha encontrado com sucesso</response>
        /// <response code="404">Horário de Linha não encontrado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SuccessResult<ReadLineTimeDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<ReadLineTimeDTO>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return (await _lineTimeService.GetByIdAsync(id, cancellationToken)).ToActionResult();
        }
    }
}
