using Microsoft.AspNetCore.Mvc;
using OneBus.Application.DTOs.LineTariffAudit;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Commons;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using Swashbuckle.AspNetCore.Annotations;

namespace OneBus.API.Controllers
{
    [SwaggerTag("Controlador responsável por gerenciar Auditoria de Tarifas da Linha")]
    public class LineTariffAuditController : BaseController<LineTariffAudit, CreateLineTariffAuditDTO, ReadLineTariffAuditDTO, UpdateLineTariffAuditDTO, BaseFilter>
    {
        public LineTariffAuditController(
            IBaseService<LineTariffAudit, CreateLineTariffAuditDTO, ReadLineTariffAuditDTO, UpdateLineTariffAuditDTO, BaseFilter> baseService) 
            : base(baseService)
        {
        }

        /// <summary>
        /// Cadastrar nova auditoria de tarifa de linha
        /// </summary>
        /// <remarks>
        /// POST de Auditoria de Tarifa de Linha
        /// </remarks>
        /// <param name="createDTO">Campos para cadastrar auditoria de tarifa de linha</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Auditoria de Tarifa de Linha cadastrada</returns>
        /// <response code="200">Auditoria de Tarifa de Linha cadastrada com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        [ProducesResponseType(typeof(SuccessResult<ReadLineTariffAuditDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadLineTariffAuditDTO>), StatusCodes.Status422UnprocessableEntity)]
        public override Task<IActionResult> CreateAsync([FromBody] CreateLineTariffAuditDTO createDTO, CancellationToken cancellationToken = default)
        {
            return base.CreateAsync(createDTO, cancellationToken);
        }

        /// <summary>
        /// Atualizar auditoria de tarifa de linha
        /// </summary>
        /// <remarks>
        /// PUT de Auditoria de Tarifa de Linha
        /// </remarks>
        /// <param name="id">Id da auditoria de tarifa de linha</param>
        /// <param name="updateDTO">Campos para atualizar auditoria de tarifa de linha</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Auditoria de Tarifa de Linha atualizada</returns>
        /// <response code="200">Auditoria de Tarifa de Linha atualizada com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        /// <response code="404">Auditoria de Tarifa de Linha não encontrada</response>
        /// <response code="409">Conflito entre ids</response>
        [ProducesResponseType(typeof(SuccessResult<ReadLineTariffAuditDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadLineTariffAuditDTO>), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(NotFoundResult<ReadLineTariffAuditDTO>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ConflictResult<ReadLineTariffAuditDTO>), StatusCodes.Status409Conflict)]
        public override Task<IActionResult> UpdateAsync([FromRoute] ulong id, [FromBody] UpdateLineTariffAuditDTO updateDTO, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(id, updateDTO, cancellationToken);
        }       

        /// <summary>
        /// Deletar auditoria de tarifa de linha
        /// </summary>
        /// <remarks>
        /// DELETE de Auditoria de Tarifa de Linha 
        /// </remarks>
        /// <param name="id">Id da auditoria de tarifa de linha</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Auditoria de Tarifa de Linha deletada</returns>
        /// <response code="200">Auditoria de Tarifa de Linha deletada com sucesso</response>
        /// <response code="404">Auditoria de Tarifa de Linha não encontrada</response>
        [ProducesResponseType(typeof(SuccessResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<bool>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> DeleteAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync(id, cancellationToken);
        }

        /// <summary>
        /// Obter auditoria de tarifas de linha paginadas e filtradas
        /// </summary>
        /// <remarks>
        /// GET de Auditoria de Tarifas de Linha
        /// </remarks>
        /// <param name="filter">Filtros para aplicar</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Auditoria de Tarifas de Linha paginadas e filtradas</returns>
        /// <response code="200">Auditoria de Tarifas de Linha paginadas e filtradas com sucesso</response>
        [ProducesResponseType(typeof(SuccessResult<Pagination<ReadLineTariffAuditDTO>>), StatusCodes.Status200OK)]
        public override Task<IActionResult> GetPaginedAsync([FromQuery] BaseFilter filter, CancellationToken cancellationToken = default)
        {
            return base.GetPaginedAsync(filter, cancellationToken);
        }

        /// <summary>
        /// Obter auditoria de tarifa de linha por id
        /// </summary>
        /// <remarks>
        /// GET pelo id da auditoria de tarifa de linha
        /// </remarks>
        /// <param name="id">Id da auditoria de tarifa de linha</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Auditoria de Tarifa de Linha encontrada</returns>
        /// <response code="200">Auditoria de Tarifa de Linha encontrada com sucesso</response>
        /// <response code="404">Auditoria de Tarifa de Linha não encontrada</response>
        [ProducesResponseType(typeof(SuccessResult<ReadLineTariffAuditDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<ReadLineTariffAuditDTO>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> GetByIdAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }
    }
}
