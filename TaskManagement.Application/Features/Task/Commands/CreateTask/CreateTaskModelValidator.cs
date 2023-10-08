using FluentValidation;
using TaskManagement.Application.Enums;

namespace TaskManagement.Application.Features.Task.Commands.CreateTask
{
    public class CreateTaskModelValidator : AbstractValidator<CreateTaskModel>
    {
        public CreateTaskModelValidator() 
        {
            RuleFor(dto => dto.Title)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(dto => dto.Description)
                .MaximumLength(500);

            RuleFor(dto => dto.DueDate)
                .GreaterThan(DateTime.UtcNow)
                .When(dto => dto.DueDate.HasValue);

            RuleFor(dto => dto.Priority)
                 .IsEnumName(typeof(TaskPriorityEnum), caseSensitive: false)
                 .WithMessage("Invalid priority value. Please provide a valid priority.");
        }
    }
}
