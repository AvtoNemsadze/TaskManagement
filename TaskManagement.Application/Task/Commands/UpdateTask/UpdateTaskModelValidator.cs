using FluentValidation;
using TaskManagement.Common.Enums;

namespace TaskManagement.Application.Task.Commands.UpdateTask
{
    public class UpdateTaskModelValidator : AbstractValidator<UpdateTaskModel>
    {
        public UpdateTaskModelValidator()
        {
            RuleFor(t => t.Title)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(100);

            RuleFor(t => t.Description)
                .MinimumLength(5)
                .MaximumLength(500);

            RuleFor(t => t.DueDate)
                .GreaterThan(DateTime.UtcNow)
                .When(dto => dto.DueDate.HasValue);

            RuleFor(t => t.Priority)
                 .IsEnumName(typeof(TaskPriorityEnum), caseSensitive: false)
                 .WithMessage("Invalid priority value. Please provide a valid priority.");
        }
    }
}
