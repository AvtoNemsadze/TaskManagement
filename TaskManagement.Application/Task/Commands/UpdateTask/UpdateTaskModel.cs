using AutoMapper;
using TaskManagement.Domain.Entities.Task;

namespace TaskManagement.Application.Task.Commands.UpdateTask
{
    public class UpdateTaskModel
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public int TaskPriorityId { get; set; }
        public string? AttachFile { get; set; }
    }

    public class UpdateTaskMapping : Profile
    {
        public UpdateTaskMapping() 
        {
            CreateMap<UpdateTaskModel, TaskEntity>();
        }    
    }
}
