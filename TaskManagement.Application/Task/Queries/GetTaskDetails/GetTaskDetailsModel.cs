using TaskManagement.Common.Mapping;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Task.Queries.GetTaskList
{
    public class GetTaskDetailsModel : MapFrom<TaskEntity>
    {
        public int Id { get; set; } 
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public string Status { get; set; } = null!;
        public string Priority { get; set; } = null!;
        public string? AttachFile { get; set; }
    }
}
