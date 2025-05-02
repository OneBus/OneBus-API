using Microsoft.AspNetCore.Mvc;
using OneBus.Application.DTOs.Feature;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Commons;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using Swashbuckle.AspNetCore.Annotations;

namespace OneBus.API.Controllers
{
    [SwaggerTag("Controlador responsável por gerenciar Funcionalidades")]
    public class FeatureController : BaseReadOnlyController<Feature, ReadFeatureDTO, BaseFilter>
    {
        public FeatureController(IBaseReadOnlyService<Feature, ReadFeatureDTO, BaseFilter> baseReadOnlyService) 
            : base(baseReadOnlyService)
        {
        }

        /// <summary>
        /// Obter funcionalidades paginadas e filtradas
        /// </summary>
        /// <remarks>
        /// GET de Funcionalidades
        /// </remarks>
        /// <param name="filter">Filtros para aplicar</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Funcionalidades paginadas e filtradas</returns>
        /// <response code="200">Funcionalidades paginadas e filtradas com sucesso</response>
        [ProducesResponseType(typeof(SuccessResult<Pagination<ReadFeatureDTO>>), StatusCodes.Status200OK)]
        public override Task<IActionResult> GetPaginedAsync([FromQuery] BaseFilter filter, CancellationToken cancellationToken = default)
        {
            return base.GetPaginedAsync(filter, cancellationToken);
        }

        /// <summary>
        /// Obter funcionalidade por id
        /// </summary>
        /// <remarks>
        /// GET pelo id da funcionalidade
        /// </remarks>
        /// <param name="id">Id da funcionalidade</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Funcionalidade encontrada</returns>
        /// <response code="200">Funcionalidade encontrada com sucesso</response>
        /// <response code="404">Funcionalidade não encontrada</response>
        [ProducesResponseType(typeof(SuccessResult<ReadFeatureDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<ReadFeatureDTO>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> GetByIdAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }
    }
}
