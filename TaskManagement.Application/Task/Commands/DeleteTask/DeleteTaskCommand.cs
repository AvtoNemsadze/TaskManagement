using MediatR;

namespace TaskManagement.Application.Task.Commands.DeleteTask
{
    public class DeleteTaskCommand : IRequest
    {
        public int TaskId { get; set; }
    }
}
