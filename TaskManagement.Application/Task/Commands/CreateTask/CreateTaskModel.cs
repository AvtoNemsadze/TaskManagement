using Microsoft.AspNetCore.Http;
using AutoMapper;

namespace TaskManagement.Application.Task.Commands.CreateTask
{
    public class CreateTaskModel
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public int TaskPriorityId { get; set; }
        public int TaskLevelId { get; set; }
        public IFormFile? File { get; set; }
    }

    public class CreateTaskMapping : Profile
    {
        public CreateTaskMapping()
        {
            CreateMap<CreateTaskModel, CreateTaskCommand>();
        }
    }
}
