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

            RuleFor(t => t.TaskPriorityId)
                .InclusiveBetween(1, 4)
                .WithMessage("'Task Priority Id' must be between 1 and 3.");
        }
    }
}
