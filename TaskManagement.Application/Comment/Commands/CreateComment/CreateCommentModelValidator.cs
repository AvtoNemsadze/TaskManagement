using FluentValidation;

namespace TaskManagement.Application.Comment.Commands.CreateComment
{

    public class CreateCommentModelValidator : AbstractValidator<CreateCommentModel>
    {
        public CreateCommentModelValidator()
        {
            RuleFor(model => model.TaskId).NotEmpty();
            RuleFor(model => model.UserId).NotEmpty();
            RuleFor(model => model.Comment).NotEmpty();
        }
    }
}
