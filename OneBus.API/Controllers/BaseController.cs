using OneBus.Application.DTOs;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using OneBus.API.Extensions;
using OneBus.Domain.Commons;
using OneBus.Domain.Commons.Result;

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
        protected readonly IBaseService<TEntity, TCreateDTO, TReadDTO, TUpdateDTO, TFilter> _baseService;

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
        [HttpPost]
        public async virtual Task<IActionResult> CreateAsync(
            [FromBody] TCreateDTO createDTO, 
            CancellationToken cancellationToken = default)
        {
            return (await _baseService.CreateAsync(createDTO, cancellationToken)).ToActionResult();
        }

        /// <summary>
        /// Atualiza registro 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateDTO"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async virtual Task<IActionResult> UpdateAsync(
            [FromRoute] ulong id, 
            [FromBody] TUpdateDTO updateDTO, 
            CancellationToken cancellationToken = default)
        {
            if (id != updateDTO.Id)            
                return ConflictResult<TUpdateDTO>.Create(ErrorUtils.IdConflict()).ToActionResult();            

            return (await _baseService.UpdateAsync(updateDTO, cancellationToken)).ToActionResult();
        }

        /// <summary>
        /// Desabilita registro 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async virtual Task<IActionResult> DisableAsync(
            [FromRoute] ulong id,
            CancellationToken cancellationToken = default)
        {
            return (await _baseService.DisableAsync(id, cancellationToken)).ToActionResult();
        }

        /// <summary>
        /// Habilita registro 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("{id}/enablements")]
        public async virtual Task<IActionResult> EnableAsync(
            [FromRoute] ulong id,
            CancellationToken cancellationToken = default)
        {
            return (await _baseService.EnableAsync(id, cancellationToken)).ToActionResult();
        }
    }
}
