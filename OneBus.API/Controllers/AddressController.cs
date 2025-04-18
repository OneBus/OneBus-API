using OneBus.Domain.Commons;
using OneBus.Domain.Filters;
using OneBus.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using OneBus.Domain.Commons.Result;
using OneBus.Application.DTOs.Address;
using Swashbuckle.AspNetCore.Annotations;
using OneBus.Application.Interfaces.Services;

namespace OneBus.API.Controllers
{
    [SwaggerTag("Controlador responsável por gerenciar Endereços")]
    public class AddressController : BaseController<Address, CreateAddressDTO, ReadAddressDTO, UpdateAddressDTO, AddressFilter>
    {
        public AddressController(
            IBaseService<Address, CreateAddressDTO, ReadAddressDTO, UpdateAddressDTO, AddressFilter> baseService) 
            : base(baseService)
        {
        }

        /// <summary>
        /// Cadastrar novo endereço 
        /// </summary>
        /// <remarks>
        /// POST de Endereço
        /// </remarks>
        /// <param name="createDTO">Campos para cadastrar endereço</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Endereço cadastrado</returns>
        /// <response code="200">Endereço cadastrado com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        [ProducesResponseType(typeof(SuccessResult<ReadAddressDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadAddressDTO>), StatusCodes.Status422UnprocessableEntity)]
        public override Task<IActionResult> CreateAsync([FromBody] CreateAddressDTO createDTO, CancellationToken cancellationToken = default)
        {            
            return base.CreateAsync(createDTO, cancellationToken);
        }

        /// <summary>
        /// Atualizar endereço 
        /// </summary>
        /// <remarks>
        /// PUT de Endereço
        /// </remarks>
        /// <param name="id">Id do endereço</param>
        /// <param name="updateDTO">Campos para atualizar endereço</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Endereço atualizado</returns>
        /// <response code="200">Endereço atualizado com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        /// <response code="404">Endereço não encontrado</response>
        /// <response code="409">Conflito entre ids</response>
        [ProducesResponseType(typeof(SuccessResult<ReadAddressDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadAddressDTO>), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(NotFoundResult<ReadAddressDTO>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ConflictResult<ReadAddressDTO>), StatusCodes.Status409Conflict)]
        public override Task<IActionResult> UpdateAsync([FromRoute] ulong id, [FromBody] UpdateAddressDTO updateDTO, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(id, updateDTO, cancellationToken);
        }

        /// <summary>
        /// Habilitar endereço 
        /// </summary>
        /// <remarks>
        /// PUT para habilitar endereço 
        /// </remarks>
        /// <param name="id">Id do endereço</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Endereço habilitado</returns>
        /// <response code="200">Endereço habilitado com sucesso</response>
        /// <response code="404">Endereço não encontrado</response>
        [ProducesResponseType(typeof(SuccessResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<bool>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> EnableAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.EnableAsync(id, cancellationToken);
        }

        /// <summary>
        /// Desabilitar endereço 
        /// </summary>
        /// <remarks>
        /// DELETE de Endereço 
        /// </remarks>
        /// <param name="id">Id do endereço</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Endereço deletado</returns>
        /// <response code="200">Endereço deletado com sucesso</response>
        /// <response code="404">Endereço não encontrado</response>
        [ProducesResponseType(typeof(SuccessResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<bool>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> DisableAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.DisableAsync(id, cancellationToken);
        }

        /// <summary>
        /// Obter endereços paginados e filtrados
        /// </summary>
        /// <remarks>
        /// GET de Endereços
        /// </remarks>
        /// <param name="filter">Filtros para aplicar</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Endereços paginados e filtrados</returns>
        /// <response code="200">Endereços paginados e filtrados com sucesso</response>
        [ProducesResponseType(typeof(SuccessResult<Pagination<ReadAddressDTO>>), StatusCodes.Status200OK)]
        public override Task<IActionResult> GetPaginedAsync([FromQuery] AddressFilter filter, CancellationToken cancellationToken = default)
        {
            return base.GetPaginedAsync(filter, cancellationToken);
        }

        /// <summary>
        /// Obter endereço por id
        /// </summary>
        /// <remarks>
        /// GET pelo id de endereço
        /// </remarks>
        /// <param name="id">Id do endereço</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Endereço encontrado</returns>
        /// <response code="200">Endereço encontrado com sucesso</response>
        /// <response code="404">Endereço não encontrado</response>
        [ProducesResponseType(typeof(SuccessResult<ReadAddressDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<ReadAddressDTO>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> GetByIdAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }
    }
}
