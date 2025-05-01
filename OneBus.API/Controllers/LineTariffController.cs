using Microsoft.AspNetCore.Mvc;
using OneBus.Application.DTOs.LineTariff;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Commons;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using Swashbuckle.AspNetCore.Annotations;

namespace OneBus.API.Controllers
{
    [SwaggerTag("Controlador responsável por gerenciar Tarifas da Linha")]
    public class LineTariffController : BaseController<LineTariff, CreateLineTariffDTO, ReadLineTariffDTO, UpdateLineTariffDTO, BaseFilter>
    {
        public LineTariffController(
            IBaseService<LineTariff, CreateLineTariffDTO, ReadLineTariffDTO, UpdateLineTariffDTO, BaseFilter> baseService) 
            : base(baseService)
        {
        }

        /// <summary>
        /// Cadastrar nova tarifa de linha 
        /// </summary>
        /// <remarks>
        /// POST de Tarifa de Linha
        /// </remarks>
        /// <param name="createDTO">Campos para cadastrar tarifa de linha</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Tarifa de Linha cadastrada</returns>
        /// <response code="200">Tarifa de Linha cadastrada com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        [ProducesResponseType(typeof(SuccessResult<ReadLineTariffDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadLineTariffDTO>), StatusCodes.Status422UnprocessableEntity)]
        public override Task<IActionResult> CreateAsync([FromBody] CreateLineTariffDTO createDTO, CancellationToken cancellationToken = default)
        {
            return base.CreateAsync(createDTO, cancellationToken);
        }

        /// <summary>
        /// Atualizar tarifa de linha 
        /// </summary>
        /// <remarks>
        /// PUT de Tarifa de Linha
        /// </remarks>
        /// <param name="id">Id da tarifa de linha</param>
        /// <param name="updateDTO">Campos para atualizar tarifa de linha</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Tarifa de Linha atualizada</returns>
        /// <response code="200">Tarifa de Linha atualizada com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        /// <response code="404">Tarifa de Linha não encontrada</response>
        /// <response code="409">Conflito entre ids</response>
        [ProducesResponseType(typeof(SuccessResult<ReadLineTariffDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadLineTariffDTO>), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(NotFoundResult<ReadLineTariffDTO>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ConflictResult<ReadLineTariffDTO>), StatusCodes.Status409Conflict)]
        public override Task<IActionResult> UpdateAsync([FromRoute] ulong id, [FromBody] UpdateLineTariffDTO updateDTO, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(id, updateDTO, cancellationToken);
        }

        /// <summary>
        /// Habilitar tarifa de linha 
        /// </summary>
        /// <remarks>
        /// PUT para habilitar tarifa de linha 
        /// </remarks>
        /// <param name="id">Id da tarifa de linha</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Tarifa de Linha habilitada</returns>
        /// <response code="200">Tarifa de Linha habilitada com sucesso</response>
        /// <response code="404">Tarifa de Linha não encontrada</response>
        [ProducesResponseType(typeof(SuccessResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<bool>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> EnableAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.EnableAsync(id, cancellationToken);
        }

        /// <summary>
        /// Desabilitar tarifa de linha
        /// </summary>
        /// <remarks>
        /// DELETE de Tarifa de Linha 
        /// </remarks>
        /// <param name="id">Id da tarifa de linha</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Tarifa de Linha deletada</returns>
        /// <response code="200">Tarifa de Linha deletada com sucesso</response>
        /// <response code="404">Tarifa de Linha não encontrada</response>
        [ProducesResponseType(typeof(SuccessResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<bool>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> DisableAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.DisableAsync(id, cancellationToken);
        }

        /// <summary>
        /// Obter tarifas de linha paginadas e filtradas
        /// </summary>
        /// <remarks>
        /// GET de Tarifas de Linha
        /// </remarks>
        /// <param name="filter">Filtros para aplicar</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Tarifas de Linha paginadas e filtradas</returns>
        /// <response code="200">Tarifas de Linha paginadas e filtradas com sucesso</response>
        [ProducesResponseType(typeof(SuccessResult<Pagination<ReadLineTariffDTO>>), StatusCodes.Status200OK)]
        public override Task<IActionResult> GetPaginedAsync([FromQuery] BaseFilter filter, CancellationToken cancellationToken = default)
        {
            return base.GetPaginedAsync(filter, cancellationToken);
        }

        /// <summary>
        /// Obter tarifa de linha por id
        /// </summary>
        /// <remarks>
        /// GET pelo id da tarifa de linha
        /// </remarks>
        /// <param name="id">Id da tarifa de linha</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Tarifa de Linha encontrada</returns>
        /// <response code="200">Tarifa de Linha encontrada com sucesso</response>
        /// <response code="404">Tarifa de Linha não encontrada</response>
        [ProducesResponseType(typeof(SuccessResult<ReadLineTariffDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<ReadLineTariffDTO>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> GetByIdAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }
    }
}
