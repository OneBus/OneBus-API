using OneBus.Application.DTOs;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.Application.Interfaces.Services
{
    public interface IBaseService<TEntity, TCreateDTO, TReadDTO, TUpdateDTO, TFilter> : IBaseReadOnlyService<TEntity, TReadDTO, TFilter>
        where TEntity    : BaseEntity
        where TCreateDTO : BaseCreateDTO
        where TReadDTO   : BaseReadDTO
        where TUpdateDTO : BaseUpdateDTO
        where TFilter    : BaseFilter
    {
        Task<Result<TReadDTO>> CreateAsync(TCreateDTO createDTO, CancellationToken cancellationToken = default);

        Task<Result<TReadDTO>> UpdateAsync(TUpdateDTO updateDTO, CancellationToken cancellationToken = default);

        Task<Result<bool>> DeleteAsync(ulong id, CancellationToken cancellationToken = default);
    }
}
