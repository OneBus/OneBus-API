using FluentValidation;
using OneBus.Application.DTOs.Line;
using OneBus.Domain.Commons;
using OneBus.Domain.Enums.Line;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Domain.Utils;

namespace OneBus.Application.Validators.Line
{
    public class UpdateLineDTOValidator : AbstractValidator<UpdateLineDTO>
    {
        private readonly ILineRepository _lineRepository;

        public UpdateLineDTOValidator(ILineRepository lineRepository)
        {
            _lineRepository = lineRepository;

            RuleFor(c => c.Id).GreaterThan(0);

            RuleFor(c => c.DirectionType)
               .Must(ValidationUtils.IsValidEnumValue<DirectionType>)
               .MustAsync(IsValidDirectionTypeAsync)
               .WithMessage(CreateLineDTOValidator.InvalidDirectionType)
               .OverridePropertyName("Tipo de Direção");

            RuleFor(c => c.Number)
               .MustAsync(async (line, number, ct) => !await IsNumberInUse(line.Id, number, ct))
               .WithMessage(ErrorUtils.AlreadyExists("Número").Message)
               .NotEmpty()
               .OverridePropertyName("Número");

            RuleFor(c => c.Name)
                .NotEmpty()
                .OverridePropertyName("Nome");
        }

        private async Task<bool> IsValidDirectionTypeAsync(UpdateLineDTO lineDTO, byte directionType, CancellationToken cancellationToken = default)
        {
            var line = await _lineRepository.GetOneAsync(c => c.Id == lineDTO.Id, cancellationToken: cancellationToken);

            if (line is null)
                return false;

            var lines = await _lineRepository.GetManyAsync(c => c.Number.ToLower().Equals(line.Number.ToLower()) && c.Type == line.Type,
                                                          cancellationToken: cancellationToken);

            if (lines is null || !lines.Any())
                return false;

            if (lines.Any(c => c.DirectionType == directionType && c.Id != line.Id))
                return false;

            if (directionType is (byte)DirectionType.Circular &&
                lines.Any(c => c.DirectionType is (byte)DirectionType.Ida or (byte)DirectionType.Volta))
                return false;

            if (directionType is (byte)DirectionType.Ida or (byte)DirectionType.Volta &&
                lines.Any(c => c.DirectionType is (byte)DirectionType.Circular))
                return false;

            return true;
        }

        private async Task<bool> IsNumberInUse(long id, string number, CancellationToken cancellationToken = default)
        {
            var line = await _lineRepository.GetOneAsync(c => c.Id == id, cancellationToken: cancellationToken);

            if (line is null)
                return false;

            return await _lineRepository.AnyAsync(c => c.Number.ToLower().Equals(number.ToLower()) &&
                                                       c.Type == line.Type && c.DirectionType == line.DirectionType && c.Id != id,
                cancellationToken: cancellationToken);
        }
    }
}
