using Mapster;
using FluentValidation;
using OneBus.Domain.Filters;
using OneBus.Domain.Entities;
using OneBus.Application.DTOs;
using FluentValidation.Results;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Commons;
using OneBus.Application.Extensions;
using OneBus.Domain.Commons.Result;

namespace OneBus.Application.Services
{
    public abstract class BaseService<TEntity, TCreateDTO, TReadDTO, TUpdateDTO, TFilter> : BaseReadOnlyService<TEntity, TReadDTO, TFilter>,
        IBaseService<TEntity, TCreateDTO, TReadDTO, TUpdateDTO, TFilter>
        where TEntity    : BaseEntity
        where TCreateDTO : BaseCreateDTO
        where TReadDTO   : BaseReadDTO
        where TUpdateDTO : BaseUpdateDTO
        where TFilter    : BaseFilter
    {
        protected readonly IBaseRepository<TEntity, TFilter> _baseRepository;
        protected readonly IValidator<TCreateDTO> _createValidator;
        protected readonly IValidator<TUpdateDTO> _updateValidator;

        protected BaseService(
            IBaseRepository<TEntity, TFilter> baseRepository,
            IValidator<TCreateDTO> createValidator,
            IValidator<TUpdateDTO> updateValidator) : base(baseRepository)
        {
            _baseRepository = baseRepository;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public virtual async Task<Result<TReadDTO>> CreateAsync(TCreateDTO createDTO, CancellationToken cancellationToken = default)
        {
            ValidationResult validation = await _createValidator.ValidateAsync(createDTO, cancellationToken);

            if (!validation.IsValid)
                return validation.Errors.ToInvalidResult<TReadDTO>();

            TEntity entity = createDTO.Adapt<TEntity>();
            entity = await _baseRepository.CreateAsync(entity, cancellationToken);

            return SuccessResult<TReadDTO>.Create(entity.Adapt<TReadDTO>());
        }

        public virtual async Task<Result<TReadDTO>> UpdateAsync(TUpdateDTO updateDTO, CancellationToken cancellationToken = default)
        {
            ValidationResult validation = await _updateValidator.ValidateAsync(updateDTO, cancellationToken);

            if (!validation.IsValid)
                return validation.Errors.ToInvalidResult<TReadDTO>();

            TEntity? entity = await _baseReadOnlyRepository.GetOneAsync(c => c.Id == updateDTO.Id, dbQueryOptions: null, cancellationToken);

            if (entity is null)
                return NotFoundResult<TReadDTO>.Create(ErrorUtils.EntityNotFound());

            UpdateFields(entity, updateDTO);
            entity = await _baseRepository.UpdateAsync(entity, cancellationToken);

            return SuccessResult<TReadDTO>.Create(entity.Adapt<TReadDTO>());
        }

        public virtual async Task<Result<bool>> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            TEntity? entity = await _baseReadOnlyRepository.GetOneAsync(c => c.Id == id,
                cancellationToken: cancellationToken);

            if (entity is null)
                return NotFoundResult<bool>.Create(ErrorUtils.EntityNotFound());

            entity.Delete();
            await _baseRepository.UpdateAsync(entity, cancellationToken);

            return SuccessResult<bool>.Create(true);
        }

        protected abstract void UpdateFields(TEntity entity, TUpdateDTO updateDTO);
    }
}
