using OneBus.Application.DTOs;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Ardalis.Result.AspNetCore;
using Ardalis.Result;

namespace OneBus.API.Controllers
{
    /// <summary>
    /// Representa a classe base para Endpoints de escrita
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TCreateDTO"></typeparam>
    /// <typeparam name="TReadDTO"></typeparam>
    /// <typeparam name="TUpdateDTO"></typeparam>
    /// <typeparam name="TFilter"></typeparam>
    public abstract class BaseController<TEntity, TCreateDTO, TReadDTO, TUpdateDTO, TFilter> : BaseReadOnlyController<TEntity, TReadDTO, TFilter>
        where TEntity    : BaseEntity
        where TCreateDTO : BaseCreateDTO
        where TReadDTO   : BaseReadDTO
        where TUpdateDTO : BaseUpdateDTO
        where TFilter    : BaseFilter
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly IBaseService<TEntity, TCreateDTO, TReadDTO, TUpdateDTO, TFilter> _baseService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseService"></param>
        protected BaseController(IBaseService<TEntity, TCreateDTO, TReadDTO, TUpdateDTO, TFilter> baseService) 
            : base(baseService)
        {
            _baseService = baseService;
        }

        /// <summary>
        /// Cadastra novo registro 
        /// </summary>
        /// <param name="createDTO"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost, TranslateResultToActionResult]
        public async Task<ActionResult<Result<TReadDTO>>> CreateAsync(
            [FromBody] TCreateDTO createDTO, 
            CancellationToken cancellationToken = default)
        {
            return await _baseService.CreateAsync(createDTO, cancellationToken);
        }

        /// <summary>
        /// Atualiza registro 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateDTO"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("{id}"), TranslateResultToActionResult]
        public async Task<ActionResult<Result<TReadDTO>>> UpdateAsync(
            [FromRoute] ulong id, 
            [FromBody] TUpdateDTO updateDTO, 
            CancellationToken cancellationToken = default)
        {
            if (id != updateDTO.Id)
                return Result<TReadDTO>.Conflict();

            return await _baseService.UpdateAsync(updateDTO, cancellationToken);
        }

        /// <summary>
        /// Desabilita registro 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{id}"), TranslateResultToActionResult]
        public async Task<ActionResult<Result<bool>>> DisableAsync(
            [FromRoute] ulong id,
            CancellationToken cancellationToken = default)
        {
            return await _baseService.DisableAsync(id, cancellationToken);
        }

        /// <summary>
        /// Habilita registro 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("{id}/enablements"), TranslateResultToActionResult]
        public async Task<ActionResult<Result<bool>>> EnableAsync(
            [FromRoute] ulong id,
            CancellationToken cancellationToken = default)
        {
            return await _baseService.EnableAsync(id, cancellationToken);
        }
    }
}
