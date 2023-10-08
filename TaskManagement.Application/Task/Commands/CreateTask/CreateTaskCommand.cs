using TaskManagement.Application.Responses;
using TaskManagement.Common.Mapping;
using MediatR;

namespace TaskManagement.Application.Task.Commands.CreateTask
{
    public class CreateTaskCommand : MapFrom<CreateTaskModel>, IRequest<BaseCommandResponse>
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public string? AttachFile { get; set; }
    }
}
