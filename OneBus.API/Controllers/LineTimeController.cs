using Microsoft.AspNetCore.Mvc;
using OneBus.Application.DTOs.LineTime;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Commons;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using Swashbuckle.AspNetCore.Annotations;

namespace OneBus.API.Controllers
{
    [SwaggerTag("Controlador responsável por gerenciar Horários da Linha")]
    public class LineTimeController : BaseController<LineTime, CreateLineTimeDTO, ReadLineTimeDTO, UpdateLineTimeDTO, BaseFilter>
    {
        public LineTimeController(
            IBaseService<LineTime, CreateLineTimeDTO, ReadLineTimeDTO, UpdateLineTimeDTO, BaseFilter> baseService) 
            : base(baseService)
        {
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
        [ProducesResponseType(typeof(SuccessResult<ReadLineTimeDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadLineTimeDTO>), StatusCodes.Status422UnprocessableEntity)]
        public override Task<IActionResult> CreateAsync([FromBody] CreateLineTimeDTO createDTO, CancellationToken cancellationToken = default)
        {
            return base.CreateAsync(createDTO, cancellationToken);
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
        [ProducesResponseType(typeof(SuccessResult<ReadLineTimeDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadLineTimeDTO>), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(NotFoundResult<ReadLineTimeDTO>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ConflictResult<ReadLineTimeDTO>), StatusCodes.Status409Conflict)]
        public override Task<IActionResult> UpdateAsync([FromRoute] ulong id, [FromBody] UpdateLineTimeDTO updateDTO, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(id, updateDTO, cancellationToken);
        }

        /// <summary>
        /// Habilitar horário de linha 
        /// </summary>
        /// <remarks>
        /// PUT para habilitar horário de linha 
        /// </remarks>
        /// <param name="id">Id do horário de linha</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Horário de Linha habilitado</returns>
        /// <response code="200">Horário de Linha habilitado com sucesso</response>
        /// <response code="404">Horário de Linha não encontrado</response>
        [ProducesResponseType(typeof(SuccessResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<bool>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> EnableAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.EnableAsync(id, cancellationToken);
        }

        /// <summary>
        /// Desabilitar horário de linha
        /// </summary>
        /// <remarks>
        /// DELETE de Horário de Linha 
        /// </remarks>
        /// <param name="id">Id do horário de linha</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Horário de Linha deletado</returns>
        /// <response code="200">Horário de Linha deletado com sucesso</response>
        /// <response code="404">Horário de Linha não encontrado</response>
        [ProducesResponseType(typeof(SuccessResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<bool>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> DisableAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.DisableAsync(id, cancellationToken);
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
        [ProducesResponseType(typeof(SuccessResult<Pagination<ReadLineTimeDTO>>), StatusCodes.Status200OK)]
        public override Task<IActionResult> GetPaginedAsync([FromQuery] BaseFilter filter, CancellationToken cancellationToken = default)
        {
            return base.GetPaginedAsync(filter, cancellationToken);
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
        [ProducesResponseType(typeof(SuccessResult<ReadLineTimeDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<ReadLineTimeDTO>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> GetByIdAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }
    }
}
