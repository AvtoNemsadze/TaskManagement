using FluentValidation;
using TaskManagement.Common.Enums;

namespace TaskManagement.Application.Task.Commands.CreateTask
{
    public class CreateTaskModelValidator : AbstractValidator<CreateTaskModel>
    {
        public CreateTaskModelValidator()
        {
            RuleFor(dto => dto.Title)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(100);

            RuleFor(dto => dto.Description)
                .MinimumLength(5)
                .MaximumLength(500);

            RuleFor(dto => dto.DueDate)
                .GreaterThan(DateTime.UtcNow)
                .When(dto => dto.DueDate.HasValue);

            RuleFor(dto => dto.TaskLevelId)
                   .InclusiveBetween(1, 3)
                   .WithMessage("'Task Level Id' must be between 1 and 3.");

            RuleFor(dto => dto.Priority)
                 .IsEnumName(typeof(TaskPriorityEnum), caseSensitive: false)
                 .WithMessage("Invalid priority value. Please provide a valid priority.");
        }
    }
}
