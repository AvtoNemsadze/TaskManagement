using MediatR;
using TaskManagement.Common.Mapping;

namespace TaskManagement.Application.Task.Commands.UpdateTask
{
    public class UpdateTaskCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public UpdateTaskModel UpdateTaskModel { get; set; }
    }
}
