using Microsoft.AspNetCore.Mvc;
using OneBus.Application.DTOs.LineAddress;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Commons;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using Swashbuckle.AspNetCore.Annotations;

namespace OneBus.API.Controllers
{
    [SwaggerTag("Controlador responsável por gerenciar Endereços da Linha")]
    public class LineAddressController : BaseController<LineAddress, CreateLineAddressDTO, ReadLineAddressDTO, UpdateLineAddressDTO, BaseFilter>
    {
        public LineAddressController(
            IBaseService<LineAddress, CreateLineAddressDTO, ReadLineAddressDTO, UpdateLineAddressDTO, BaseFilter> baseService) 
            : base(baseService)
        {
        }

        /// <summary>
        /// Cadastrar novo endereço de linha 
        /// </summary>
        /// <remarks>
        /// POST de Endereço Linha
        /// </remarks>
        /// <param name="createDTO">Campos para cadastrar endereço de linha</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Endereço de Linha cadastrado</returns>
        /// <response code="200">Endereço de Linha cadastrado com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        [ProducesResponseType(typeof(SuccessResult<ReadLineAddressDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadLineAddressDTO>), StatusCodes.Status422UnprocessableEntity)]
        public override Task<IActionResult> CreateAsync([FromBody] CreateLineAddressDTO createDTO, CancellationToken cancellationToken = default)
        {
            return base.CreateAsync(createDTO, cancellationToken);
        }

        /// <summary>
        /// Atualizar endereço de linha 
        /// </summary>
        /// <remarks>
        /// PUT de Endereço Linha
        /// </remarks>
        /// <param name="id">Id de endereço de linha</param>
        /// <param name="updateDTO">Campos para atualizar endereço de linha</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Endereço de Linha atualizado</returns>
        /// <response code="200">Endereço de Linha atualizado com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        /// <response code="404">Endereço de Linha não encontrado</response>
        /// <response code="409">Conflito entre ids</response>
        [ProducesResponseType(typeof(SuccessResult<ReadLineAddressDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadLineAddressDTO>), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(NotFoundResult<ReadLineAddressDTO>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ConflictResult<ReadLineAddressDTO>), StatusCodes.Status409Conflict)]
        public override Task<IActionResult> UpdateAsync([FromRoute] ulong id, [FromBody] UpdateLineAddressDTO updateDTO, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(id, updateDTO, cancellationToken);
        }

        /// <summary>
        /// Habilitar endereço de linha 
        /// </summary>
        /// <remarks>
        /// PUT para habilitar endereço de linha 
        /// </remarks>
        /// <param name="id">Id de endereço de linha</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Endereço de Linha habilitado</returns>
        /// <response code="200">Endereço de Linha habilitado com sucesso</response>
        /// <response code="404">Endereço de Linha não encontrado</response>
        [ProducesResponseType(typeof(SuccessResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<bool>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> EnableAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.EnableAsync(id, cancellationToken);
        }

        /// <summary>
        /// Desabilitar endereço de linha
        /// </summary>
        /// <remarks>
        /// DELETE de Endereço Linha 
        /// </remarks>
        /// <param name="id">Id de endereço de linha</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Endereço de Linha deletado</returns>
        /// <response code="200">Endereço de Linha deletado com sucesso</response>
        /// <response code="404">Endereço de Linha não encontrado</response>
        [ProducesResponseType(typeof(SuccessResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<bool>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> DisableAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.DisableAsync(id, cancellationToken);
        }

        /// <summary>
        /// Obter endereços de linha paginados e filtrados
        /// </summary>
        /// <remarks>
        /// GET de Endereços Linha
        /// </remarks>
        /// <param name="filter">Filtros para aplicar</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Endereços de Linha paginados e filtrados</returns>
        /// <response code="200">Endereços de Linha paginados e filtrados com sucesso</response>
        [ProducesResponseType(typeof(SuccessResult<Pagination<ReadLineAddressDTO>>), StatusCodes.Status200OK)]
        public override Task<IActionResult> GetPaginedAsync([FromQuery] BaseFilter filter, CancellationToken cancellationToken = default)
        {
            return base.GetPaginedAsync(filter, cancellationToken);
        }

        /// <summary>
        /// Obter endereço de linha por id
        /// </summary>
        /// <remarks>
        /// GET pelo id de endereço de linha
        /// </remarks>
        /// <param name="id">Id de endereço de linha</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Endereço de Linha encontrado</returns>
        /// <response code="200">Endereço de Linha encontrado com sucesso</response>
        /// <response code="404">Endereço de Linha não encontrado</response>
        [ProducesResponseType(typeof(SuccessResult<ReadLineAddressDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<ReadLineAddressDTO>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> GetByIdAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }
    }
}
