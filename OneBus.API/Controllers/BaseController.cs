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

        [HttpPost]
        public async virtual Task<IActionResult> CreateAsync(
            [FromBody] TCreateDTO createDTO,
            CancellationToken cancellationToken = default)
        {
            return (await _baseService.CreateAsync(createDTO, cancellationToken)).ToActionResult();
        }

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

        [HttpDelete("{id}")]
        public async virtual Task<IActionResult> DeleteAsync(
            [FromRoute] ulong id,
            CancellationToken cancellationToken = default)
        {
            return (await _baseService.DeleteAsync(id, cancellationToken)).ToActionResult();
        }
    }
}
