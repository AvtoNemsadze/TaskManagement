using TaskManagement.Application.Responses;
using TaskManagement.Common.Mapping;
using MediatR;

namespace TaskManagement.Application.Task.Commands.CreateTask
{
    public class CreateTaskCommand : IRequest<BaseCommandResponse>
    {
        public CreateTaskModel CreateTaskModel { get; set; } = null!;
    }
}
