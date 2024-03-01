using MediatR;
using TaskManagement.Application.Responses;

namespace TaskManagement.Application.Task.Commands.DuplicateTask
{
    public class DuplicateTaskCommand : IRequest<BaseCommandResponse>
    {
        public int TaskId { get; set; }
    }
}
