using Microsoft.AspNetCore.Mvc;
using OneBus.Application.DTOs.BusAudit;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Commons;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using Swashbuckle.AspNetCore.Annotations;

namespace OneBus.API.Controllers
{
    [SwaggerTag("Controlador responsável por gerenciar Auditorias de Ônibus")]
    public class BusAuditController : BaseController<BusAudit, CreateBusAuditDTO, ReadBusAuditDTO, UpdateBusAuditDTO, BaseFilter>
    {
        public BusAuditController(
            IBaseService<BusAudit, CreateBusAuditDTO, ReadBusAuditDTO, UpdateBusAuditDTO, BaseFilter> baseService) 
            : base(baseService)
        {
        }

        /// <summary>
        /// Cadastrar nova auditoria de ônibus 
        /// </summary>
        /// <remarks>
        /// POST de Auditoria de Ônibus
        /// </remarks>
        /// <param name="createDTO">Campos para cadastrar auditoria de ônibus</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Auditoria de Ônibus cadastrada</returns>
        /// <response code="200">Auditoria de Ônibus cadastrada com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        [ProducesResponseType(typeof(SuccessResult<ReadBusAuditDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadBusAuditDTO>), StatusCodes.Status422UnprocessableEntity)]
        public override Task<IActionResult> CreateAsync([FromBody] CreateBusAuditDTO createDTO, CancellationToken cancellationToken = default)
        {
            return base.CreateAsync(createDTO, cancellationToken);
        }

        /// <summary>
        /// Atualizar auditoria de ônibus  
        /// </summary>
        /// <remarks>
        /// PUT de Auditoria de Ônibus
        /// </remarks>
        /// <param name="id">Id da auditoria de ônibus </param>
        /// <param name="updateDTO">Campos para atualizar auditoria de ônibus</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Auditoria de Ônibus atualizada</returns>
        /// <response code="200">Auditoria de Ônibus atualizada com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        /// <response code="404">Auditoria de Ônibus não encontrada</response>
        /// <response code="409">Conflito entre ids</response>
        [ProducesResponseType(typeof(SuccessResult<ReadBusAuditDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadBusAuditDTO>), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(NotFoundResult<ReadBusAuditDTO>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ConflictResult<ReadBusAuditDTO>), StatusCodes.Status409Conflict)]
        public override Task<IActionResult> UpdateAsync([FromRoute] ulong id, [FromBody] UpdateBusAuditDTO updateDTO, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(id, updateDTO, cancellationToken);
        }

        /// <summary>
        /// Habilitar auditoria de ônibus 
        /// </summary>
        /// <remarks>
        /// PUT para habilitar auditoria de ônibus 
        /// </remarks>
        /// <param name="id">Id da auditoria de ônibus</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Auditoria de Ônibus habilitada</returns>
        /// <response code="200">Auditoria de Ônibus habilitada com sucesso</response>
        /// <response code="404">Auditoria de Ônibus não encontrada</response>
        [ProducesResponseType(typeof(SuccessResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<bool>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> EnableAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.EnableAsync(id, cancellationToken);
        }

        /// <summary>
        /// Desabilitar auditoria de ônibus  
        /// </summary>
        /// <remarks>
        /// DELETE de Auditoria de Ônibus 
        /// </remarks>
        /// <param name="id">Id da auditoria de ônibus</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Auditoria de Ônibus deletada</returns>
        /// <response code="200">Auditoria de Ônibus deletada com sucesso</response>
        /// <response code="404">Auditoria de Ônibus não encontrada</response>
        [ProducesResponseType(typeof(SuccessResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<bool>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> DisableAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.DisableAsync(id, cancellationToken);
        }

        /// <summary>
        /// Obter auditorias de ônibus paginadas e filtradas
        /// </summary>
        /// <remarks>
        /// GET de Auditorias de Ônibus
        /// </remarks>
        /// <param name="filter">Filtros para aplicar</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Auditorias de Ônibus paginadas e filtradas</returns>
        /// <response code="200">Auditorias de Ônibus paginadas e filtradas com sucesso</response>
        [ProducesResponseType(typeof(SuccessResult<Pagination<ReadBusAuditDTO>>), StatusCodes.Status200OK)]
        public override Task<IActionResult> GetPaginedAsync([FromQuery] BaseFilter filter, CancellationToken cancellationToken = default)
        {
            return base.GetPaginedAsync(filter, cancellationToken);
        }

        /// <summary>
        /// Obter auditoria de ônibus por id
        /// </summary>
        /// <remarks>
        /// GET pelo id da auditoria de ônibus
        /// </remarks>
        /// <param name="id">Id da auditoria de ônibus</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Auditoria de Ônibus encontrada</returns>
        /// <response code="200">Auditoria de Ônibus encontrada com sucesso</response>
        /// <response code="404">Auditoria de Ônibus não encontrada</response>
        [ProducesResponseType(typeof(SuccessResult<ReadBusAuditDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<ReadBusAuditDTO>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> GetByIdAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }
    }
}
