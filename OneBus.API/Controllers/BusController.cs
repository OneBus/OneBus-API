using Microsoft.AspNetCore.Mvc;
using OneBus.Application.DTOs.Bus;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Commons;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using Swashbuckle.AspNetCore.Annotations;

namespace OneBus.API.Controllers
{
    [SwaggerTag("Controlador responsável por gerenciar Ônibus")]
    public class BusController : BaseController<Bus, CreateBusDTO, ReadBusDTO, UpdateBusDTO, BaseFilter>
    {
        public BusController(
            IBaseService<Bus, CreateBusDTO, ReadBusDTO, UpdateBusDTO, BaseFilter> baseService) 
            : base(baseService)
        {
        }

        /// <summary>
        /// Cadastrar novo ônibus 
        /// </summary>
        /// <remarks>
        /// POST de Ônibus
        /// </remarks>
        /// <param name="createDTO">Campos para cadastrar ônibus</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Ônibus cadastrado</returns>
        /// <response code="200">Ônibus cadastrado com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        [ProducesResponseType(typeof(SuccessResult<ReadBusDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadBusDTO>), StatusCodes.Status422UnprocessableEntity)]
        public override Task<IActionResult> CreateAsync([FromBody] CreateBusDTO createDTO, CancellationToken cancellationToken = default)
        {
            return base.CreateAsync(createDTO, cancellationToken);
        }

        /// <summary>
        /// Atualizar ônibus 
        /// </summary>
        /// <remarks>
        /// PUT de Ônibus
        /// </remarks>
        /// <param name="id">Id do ônibus</param>
        /// <param name="updateDTO">Campos para atualizar ônibus</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Ônibus atualizado</returns>
        /// <response code="200">Ônibus atualizado com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        /// <response code="404">Ônibus não encontrado</response>
        /// <response code="409">Conflito entre ids</response>
        [ProducesResponseType(typeof(SuccessResult<ReadBusDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadBusDTO>), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(NotFoundResult<ReadBusDTO>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ConflictResult<ReadBusDTO>), StatusCodes.Status409Conflict)]
        public override Task<IActionResult> UpdateAsync([FromRoute] ulong id, [FromBody] UpdateBusDTO updateDTO, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(id, updateDTO, cancellationToken);
        }

        /// <summary>
        /// Habilitar ônibus 
        /// </summary>
        /// <remarks>
        /// PUT para habilitar ônibus 
        /// </remarks>
        /// <param name="id">Id do ônibus</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Ônibus habilitado</returns>
        /// <response code="200">Ônibus habilitado com sucesso</response>
        /// <response code="404">Ônibus não encontrado</response>
        [ProducesResponseType(typeof(SuccessResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<bool>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> EnableAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.EnableAsync(id, cancellationToken);
        }

        /// <summary>
        /// Desabilitar ônibus 
        /// </summary>
        /// <remarks>
        /// DELETE de ônibus 
        /// </remarks>
        /// <param name="id">Id do ônibus</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Ônibus deletado</returns>
        /// <response code="200">Ônibus deletado com sucesso</response>
        /// <response code="404">Ônibus não encontrado</response>
        [ProducesResponseType(typeof(SuccessResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<bool>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> DisableAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.DisableAsync(id, cancellationToken);
        }

        /// <summary>
        /// Obter ônibus paginados e filtrados
        /// </summary>
        /// <remarks>
        /// GET de ônibus
        /// </remarks>
        /// <param name="filter">Filtros para aplicar</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Ônibus paginados e filtrados</returns>
        /// <response code="200">Ônibus paginados e filtrados com sucesso</response>
        [ProducesResponseType(typeof(SuccessResult<Pagination<ReadBusDTO>>), StatusCodes.Status200OK)]
        public override Task<IActionResult> GetPaginedAsync([FromQuery] BaseFilter filter, CancellationToken cancellationToken = default)
        {
            return base.GetPaginedAsync(filter, cancellationToken);
        }

        /// <summary>
        /// Obter ônibus por id
        /// </summary>
        /// <remarks>
        /// GET pelo id de ônibus
        /// </remarks>
        /// <param name="id">Id do ônibus</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Ônibus encontrado</returns>
        /// <response code="200">Ônibus encontrado com sucesso</response>
        /// <response code="404">Ônibus não encontrado</response>
        [ProducesResponseType(typeof(SuccessResult<ReadBusDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<ReadBusDTO>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> GetByIdAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }
    }
}
