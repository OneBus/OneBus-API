using FluentValidation;
using OneBus.Application.DTOs.Line;
using OneBus.Domain.Commons;
using OneBus.Domain.Enums.Line;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Domain.Utils;

namespace OneBus.Application.Validators.Line
{
    public class CreateLineDTOValidator : AbstractValidator<CreateLineDTO>
    {
        private readonly ILineRepository _lineRepository;

        public const string InvalidDirectionType = "Tipo de Direção inválida, verifique se a linha é circular ou a direção é repetida.";

        public CreateLineDTOValidator(ILineRepository lineRepository)
        {
            _lineRepository = lineRepository;

            RuleFor(c => c.Type)
               .Must(ValidationUtils.IsValidEnumValue<LineType>)
               .OverridePropertyName("Tipo");

            RuleFor(c => c.DirectionType)
               .Must(ValidationUtils.IsValidEnumValue<DirectionType>)
               .MustAsync(IsValidDirectionTypeAsync)
               .WithMessage(InvalidDirectionType)
               .OverridePropertyName("Tipo de Direção");

            RuleFor(c => c.Number)
               .MustAsync(async (line, number, ct) => !await IsNumberInUse(number, line.Type, line.DirectionType, ct))
               .WithMessage(ErrorUtils.AlreadyExists("Número").Message)
               .NotEmpty()
               .OverridePropertyName("Número");

            RuleFor(c => c.Name)
                .NotEmpty()
                .OverridePropertyName("Nome");
        }

        private async Task<bool> IsValidDirectionTypeAsync(CreateLineDTO lineDTO, byte directionType, CancellationToken cancellationToken = default)
        {
            var lines = await _lineRepository.GetManyAsync(c => c.Number.ToLower().Equals(lineDTO.Number.ToLower()) && c.Type == lineDTO.Type,
                                                         cancellationToken: cancellationToken);

            if (lines is null || !lines.Any())
                return true;

            if (lines.Any(c => c.DirectionType == directionType))
                return false;

            if (directionType is (byte)DirectionType.Circular &&
                lines.Any(c => c.DirectionType is (byte)DirectionType.Ida or (byte)DirectionType.Volta))
                return false;

            if (directionType is (byte)DirectionType.Ida or (byte)DirectionType.Volta &&
                lines.Any(c => c.DirectionType is (byte)DirectionType.Circular))
                return false;

            return true;
        }

        private async Task<bool> IsNumberInUse(string number, byte type, byte directionType, CancellationToken cancellationToken = default)
        {
            return await _lineRepository.AnyAsync(c => c.Number.ToLower().Equals(number.ToLower()) && c.Type == type && c.DirectionType == directionType,
                cancellationToken: cancellationToken);
        }
    }
}
