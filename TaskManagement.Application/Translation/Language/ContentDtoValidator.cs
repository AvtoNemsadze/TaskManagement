using FluentValidation;

namespace TaskManagement.Application.Translation.Language
{
    public class AddContentRequestDtoValidator : AbstractValidator<AddContentRequestDto>
    {
        public AddContentRequestDtoValidator()
        {
            RuleFor(dto => dto.Key)
                .NotEmpty().WithMessage("Key is required.");

            RuleFor(dto => dto.Translations)
                .NotEmpty().WithMessage("Translations is required.");

            RuleForEach(dto => dto.Translations)
            .ChildRules(translation =>
            {
                translation.RuleFor(t => t.Value)
                    .NotEmpty().WithMessage("Value is required.");

                translation.RuleFor(t => t.LanguageId)
                    .NotEmpty().WithMessage("LanguageId is required.");
            });
        }
    }

}
