using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneBus.API.Extensions;
using OneBus.Application.DTOs;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.API.Controllers
{
    /// <summary>
    /// Representa a classe base para Endpoints somente leitura
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public abstract class BaseReadOnlyController<TEntity, TReadDTO, TFilter> : ControllerBase
        where TEntity  : BaseEntity
        where TReadDTO : BaseReadDTO
        where TFilter  : BaseFilter
    {
        protected readonly IBaseReadOnlyService<TEntity, TReadDTO, TFilter> _baseReadOnlyService;
        
        protected BaseReadOnlyController(IBaseReadOnlyService<TEntity, TReadDTO, TFilter> baseReadOnlyService)
        {
            _baseReadOnlyService = baseReadOnlyService;
        }

        /// <summary>
        /// Obter itens paginados por filtro
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async virtual Task<IActionResult> GetPaginedAsync(
            [FromQuery] TFilter filter, 
            CancellationToken cancellationToken = default)
        {
            return (await _baseReadOnlyService.GetPaginedAsync(filter, cancellationToken)).ToActionResult();
        }

        /// <summary>
        /// Obter por Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async virtual Task<IActionResult> GetPaginedAsync(
            [FromRoute] ulong id, 
            CancellationToken cancellationToken = default)
        {
            return (await _baseReadOnlyService.GetByIdAsync(id, cancellationToken)).ToActionResult();
        }        
    }
}
