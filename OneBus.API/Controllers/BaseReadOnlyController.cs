using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneBus.Application.DTOs;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Commons;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.API.Controllers
{
    /// <summary>
    /// Representa a classe base para Endpoints somente leitura
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public abstract class BaseReadOnlyController<TEntity, TReadDTO, TFilter> : ControllerBase
        where TEntity  : BaseEntity
        where TReadDTO : BaseReadDTO
        where TFilter  : BaseFilter
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly IBaseReadOnlyService<TEntity, TReadDTO, TFilter> _baseReadOnlyService;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseReadOnlyService"></param>
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
        [HttpGet, TranslateResultToActionResult]
        public async Task<ActionResult<Result<Pagination<TReadDTO>>>> GetPaginedAsync([FromQuery] TFilter filter, CancellationToken cancellationToken = default)
        {
            return await _baseReadOnlyService.GetPaginedAsync(filter, cancellationToken);
        }

        /// <summary>
        /// Obter por Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}"), TranslateResultToActionResult]
        public async Task<ActionResult<Result<TReadDTO>>> GetPaginedAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return await _baseReadOnlyService.GetByIdAsync(id, cancellationToken);
        }        
    }
}
