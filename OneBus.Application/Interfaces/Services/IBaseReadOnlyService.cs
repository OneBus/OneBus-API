using OneBus.Application.DTOs;
using OneBus.Domain.Commons;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.Application.Interfaces.Services
{
    public interface IBaseReadOnlyService<TEntity, TReadDTO, TFilter>
        where TEntity  : BaseEntity
        where TReadDTO : BaseReadDTO
        where TFilter  : BaseFilter
    {
        Task<Result<Pagination<TReadDTO>>> GetPaginedAsync(
            TFilter filter,
            CancellationToken cancellationToken = default);

        Task<Result<TReadDTO>> GetByIdAsync(
            long id, 
            CancellationToken cancellationToken = default);    
    }
}
