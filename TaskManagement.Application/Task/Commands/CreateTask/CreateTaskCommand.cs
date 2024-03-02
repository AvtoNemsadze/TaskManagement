using TaskManagement.Application.Responses;
using TaskManagement.Common.Mapping;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace TaskManagement.Application.Task.Commands.CreateTask
{
    public class CreateTaskCommand : IRequest<BaseCommandResponse>
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public int TaskPriorityId { get; set; }
        public int TaskLevelId { get; set; }
        public IFormFile? File { get; set; }
    }
}
