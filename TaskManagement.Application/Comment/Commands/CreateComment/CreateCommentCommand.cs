using MediatR;
using TaskManagement.Application.Responses;

namespace TaskManagement.Application.Comment.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<BaseCommandResponse>
    {
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; } = null!;
    }
}
