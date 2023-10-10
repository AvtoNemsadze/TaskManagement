using MediatR;

namespace TaskManagement.Application.Task.Commands.DeleteTask
{
    public class DeleteTaskCommand : IRequest
    {
        public long TaskId { get; set; }
    }
}
