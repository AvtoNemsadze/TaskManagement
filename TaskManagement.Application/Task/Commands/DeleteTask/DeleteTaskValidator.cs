using FluentValidation;

namespace TaskManagement.Application.Task.Commands.DeleteTask
{
    public class DeleteTaskValidator : AbstractValidator<DeleteTaskCommand>
    {
        public DeleteTaskValidator() 
        {
            RuleFor(s => s.TaskId).NotEmpty().WithName("Id is Required");
        }
    }
}
