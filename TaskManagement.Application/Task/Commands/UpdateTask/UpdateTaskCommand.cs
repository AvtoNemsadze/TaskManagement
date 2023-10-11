using MediatR;
using TaskManagement.Common.Mapping;

namespace TaskManagement.Application.Task.Commands.UpdateTask
{
    public class UpdateTaskCommand : MapFrom<UpdateTaskModel>, IRequest<Unit>
    {
        public long Id { get; set; } 
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public string Priority { get; set; }
        public string? AttachFile { get; set; }
    }
}
